using Gameplay;
using Gameplay.DayNight;
using Gameplay.GiftManager.Config;
using Gameplay.Gifts;
using Gameplay.Planet;
using Gameplay.Player.Config;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace DI
{
    public class GameplayInstaller : MonoInstaller
    {
        [Header("Configurations")]
        [SerializeField] private PlayerConfig playerConfig;

        [SerializeField] private GiftManagerConfig giftManagerConfig;
        
        [Space]
        [SerializeField] private Planet planet;
        [SerializeField] private UpdateBehaviour updateBehaviour;
        [SerializeField] private CinemachineCamera camera;
        [SerializeField] private DayNightCycler dayNightCycler;
        public override void InstallBindings()
        {
            Container.BindInstance(camera);
            Container.BindInstance(planet);
            Container.BindInstance(updateBehaviour);
            Container.BindInstance(dayNightCycler);
            
            Container.BindInstance(playerConfig);
            Container.BindInstance(giftManagerConfig);
            
            Container.BindInterfacesAndSelfTo<GameplayEntryPoint>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GiftManager>().AsSingle().NonLazy();
        }
    }
}
