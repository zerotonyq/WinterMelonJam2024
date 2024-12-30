using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UI.Base.Config;
using UnityEngine.AddressableAssets;
using Zenject;

namespace UI.Base
{
    public abstract class UICongtroller<T, C> where T : UIConfig where C : CanvasContainer
    {
        protected abstract C CanvasContainer { get; set; }
        protected SignalBus _signalBus;

        public virtual async Task Initialize(T config, SignalBus signalBus)
        {
            _signalBus = signalBus;
            CanvasContainer = (await Addressables.InstantiateAsync(config.CanvasReference)).GetComponent<C>();
        }
    }
}