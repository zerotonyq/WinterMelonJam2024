using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Gameplay.GiftManager.Config
{
    [CreateAssetMenu(menuName = "CreateConfig/" + nameof(GiftManagerConfig), fileName = nameof(GiftManagerConfig))]
    public class GiftManagerConfig : ScriptableObject
    {
        public List<AssetReferenceGameObject> GiftPlaces = new();
    }
}