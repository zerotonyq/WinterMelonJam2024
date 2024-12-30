using Cysharp.Threading.Tasks;
using Gameplay.DayNight;
using Gameplay.Factories;
using Gameplay.Player.Config;
using InputSystem;
using Unity.Cinemachine;
using Zenject;

namespace Gameplay
{
    public class GameplayEntryPoint
    {
        [Inject]
        public async UniTaskVoid Initialize(
            CinemachineCamera camera,
            UpdateBehaviour updateBehaviour,
            InputProvider inputProvider,
            PlayerConfig playerConfig,
            DayNightCycler dayNightCycler,
            Planet.Planet planet)
        {
            var player = await PlayerFactory.CreatePlayer(updateBehaviour, inputProvider, playerConfig, planet);

            camera.Target = new CameraTarget
            {
                TrackingTarget = player.transform
            };
            
            dayNightCycler.StartCycle();
        }
    }
}