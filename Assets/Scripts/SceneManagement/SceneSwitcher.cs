using System;
using Signals;
using UnityEngine.SceneManagement;
using Zenject;

namespace SceneManagement
{
    public class SceneSwitcher : IDisposable
    {
        private SignalBus _signalBus;
        public SceneSwitcher(SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<StartGameRequest>(OnStartGameRequested);
        }

        public void Dispose()
        {
            _signalBus.Unsubscribe<StartGameRequest>(OnStartGameRequested);
        }

        private static void OnStartGameRequested() => SceneManager.LoadSceneAsync(0);
    }
}