using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Serialization;

namespace Gameplay.Player.Config
{
    [CreateAssetMenu(menuName = "CreateConfig/" + nameof(PlayerConfig), fileName = nameof(PlayerConfig))]
    public class PlayerConfig : ScriptableObject
    {
        public AssetReferenceGameObject playerReference;
        public int acceleration;
        public int jumpImpulse;
    }
}