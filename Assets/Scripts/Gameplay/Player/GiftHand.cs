using System.Collections.Generic;
using System.Linq;
using Gameplay.Gifts;
using UnityEngine;

namespace Gameplay.Player
{
    public class GiftHand : MonoBehaviour
    {
        public float radius;
        private ContactFilter2D _contactFilter2D;
        private List<Collider2D> colls = new();
        
        public void Initialize()
        {
            _contactFilter2D = new ContactFilter2D()
            {
                layerMask = 1 << LayerMask.NameToLayer("GiftPlace")
            };
        }

        public void Scan()
        {
            Physics2D.OverlapCircle(transform.position, radius, _contactFilter2D, colls);

            Debug.Log("scanned " + colls.Count(c => c.TryGetComponent(out GiftPlace gp)) + " gift places");
            foreach (var coll in colls)
            {
                if(!coll.TryGetComponent(out GiftPlace giftPlace))
                    continue;
                
                giftPlace.Put();
            }
            colls.Clear();
        }
    }
}