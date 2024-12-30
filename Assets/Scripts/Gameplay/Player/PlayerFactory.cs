using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Gameplay.Core.Rotation;
using Gameplay.Movement;
using Gameplay.Player;
using Gameplay.Player.Config;
using InputSystem;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Gameplay.Factories
{
    public static class PlayerFactory
    {
        
        public static async Task<PlayerComponent> CreatePlayer(UpdateBehaviour updateBehaviour,
            InputProvider inputProvider,
            PlayerConfig config,
            Planet.Planet planet)
        {
            //instantiate
            var obj = (await Addressables.InstantiateAsync(config.playerReference, planet.GetPointOnPlanet(90f), Quaternion.identity));

            //get init
            var playerMovement = obj.GetComponent<MovementComponent>();
            var playerJump = obj.GetComponent<JumpComponent>();
            var groundCheckerComponent = obj.GetComponent<GroundCheckerComponent>();
            var playerGravitation = obj.GetComponent<GravitationRotationComponent>();

            playerMovement.Initialize(config.acceleration);
            groundCheckerComponent.Initialize();
            playerJump.Initialize(config.jumpImpulse);
            playerGravitation.Initialize(planet.Center);

            //subs
            groundCheckerComponent.GroundStateChanged += playerJump.JumpAllowed;

            //update beh
            updateBehaviour.Executables.Add(playerMovement);
            updateBehaviour.Executables.Add(groundCheckerComponent);
            
            //input
            inputProvider.InputSystemActions.Player.Move.started +=
                ctx => playerMovement.StartMoving(ctx.ReadValue<Vector2>().x > 0);
            inputProvider.InputSystemActions.Player.Move.canceled +=
                ctx => playerMovement.StopMoving();

            inputProvider.InputSystemActions.Player.Jump.performed += ctx => playerJump.Jump();

            InitializeGiftHand(obj, inputProvider);
            
            return obj.GetComponent<PlayerComponent>();
        }

        private static void InitializeGiftHand(GameObject obj, InputProvider inputProvider)
        {
            if (!obj.TryGetComponent(out GiftHand hand))
            {
                Debug.LogError("there is no hand on player ");
                return;
            }

            inputProvider.InputSystemActions.Player.Interact.started += _ => hand.Scan();
            
            hand.Initialize();
        }
    }
}