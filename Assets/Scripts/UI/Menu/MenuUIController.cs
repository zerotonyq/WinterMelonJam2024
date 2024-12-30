using System;
using System.Threading.Tasks;
using Signals;
using UI.Base;
using UI.Menu.Config;
using Zenject;

namespace UI.Menu
{
    public class MenuUIController : UICongtroller<MenuUIConfig, MenuUICanvasContainer>, IDisposable
    {
        protected override MenuUICanvasContainer CanvasContainer { get; set; }

        [Inject]
        public override async Task Initialize(MenuUIConfig config, SignalBus signalBus)
        {
             await base.Initialize(config, signalBus);
             
             CanvasContainer.StartGameButton.onClick.AddListener(() => _signalBus.Fire(new StartGameRequest()));
        }

        public void Dispose()
        {
            CanvasContainer.StartGameButton.onClick.RemoveAllListeners();
        }
    }
}