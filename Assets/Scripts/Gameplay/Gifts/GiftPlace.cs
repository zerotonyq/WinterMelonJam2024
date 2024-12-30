using System;
using UnityEngine;

namespace Gameplay.Gifts
{
    [RequireComponent(typeof(Collider2D))]
    public class GiftPlace : MonoBehaviour
    {
        private bool _opened;
        public bool Success { get; private set; }

        public void Put()
        {
            if (!_opened)
                return;
            Success = true;
            Debug.Log("SUCCESSFULLY PUT GIFT");
        }

        public void Open()
        {
            _opened = true;
        }

        public void Close()
        {
            _opened = false;
        }
    }
}