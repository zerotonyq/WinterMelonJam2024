using InputSystem;
using SceneManagement;
using Signals;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.U2D;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        DeclareSignals();
        
        SignalBusInstaller.Install(Container);

        Container.BindInterfacesAndSelfTo<InputProvider>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<SceneSwitcher>().AsSingle().NonLazy();
        
        Addressables.InitializeAsync();
    }

    private void DeclareSignals()
    {
        Container.DeclareSignal<StartGameRequest>();
        Container.DeclareSignal<EndGameRequest>();
    }
}
