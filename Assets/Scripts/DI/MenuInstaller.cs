using Signals;
using UI.Menu;
using Zenject;

namespace DI
{
    public class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            
            Container.BindInterfacesAndSelfTo<MenuUIController>().AsSingle().NonLazy();
        }
    }
}