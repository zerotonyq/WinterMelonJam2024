using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Gameplay.DayNight;
using Gameplay.GiftManager.Config;
using Signals;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Zenject;

namespace Gameplay.Gifts
{
    public class GiftManager
    {
        private List<GiftPlace> _giftPlaces = new();

        private SignalBus _signalBus;

        [Inject]
        public async Task Initialize(
            GiftManagerConfig config,
            Planet.Planet planet,
            DayNightCycler dayNightCycler,
            SignalBus signalBus)
        {
            _signalBus = signalBus;

            var angle = 90f;
            for (var index = 0; index < config.GiftPlaces.Count; index++)
            {
                var referenceGameObject = config.GiftPlaces[index];
                var place = (await Addressables.InstantiateAsync(referenceGameObject)).GetComponent<GiftPlace>();

                place.transform.position = planet.GetPointOnPlanet(angle);
                angle += 30;

                _giftPlaces.Add(place);
            }

            dayNightCycler.CycleStarted += OpenGiftPlaces;
            dayNightCycler.CycleEnded += CheckPlaces;
        }

        private void CheckPlaces()
        {
            CloseGiftPlaces();
            
            foreach (var giftPlace in _giftPlaces)
            {
                if (!giftPlace.Success)
                {
                    _signalBus.Fire(new EndGameRequest { IsWin = false });
                    Debug.Log("LOSE");
                }
                
            }

            _signalBus.Fire(new EndGameRequest { IsWin = true });
                    Debug.Log("WIN");
        }

        private void CloseGiftPlaces()
        {
            foreach (var giftPlace in _giftPlaces)
            {
                giftPlace.Close();
            }
        }

        private void OpenGiftPlaces()
        {
            foreach (var giftPlace in _giftPlaces)
            {
                giftPlace.Open();
            }
        }
    }
}