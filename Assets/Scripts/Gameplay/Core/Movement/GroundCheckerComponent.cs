using System;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Base;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Movement
{
    [RequireComponent(typeof(Collider2D))]
    public class GroundCheckerComponent : MonoBehaviour, IExecutable
    {
        private Collider2D _collider;

        public Action<bool> GroundStateChanged;

        public void Initialize()
        {
            _collider = GetComponent<Collider2D>();

            if (_collider.isTrigger)
                throw new ArgumentException("Cannot be trigger");
        }

        private List<Collider2D> colls = new();

        public void Execute()
        {
            Physics2D.OverlapCircle(transform.position - transform.up * _collider.bounds.size.y, 0.5f,
                new ContactFilter2D() { layerMask = 1 << LayerMask.NameToLayer("Jumpable") }, colls);

            var isGrounded = colls.Any(coll => coll != _collider);
            GroundStateChanged?.Invoke(isGrounded);
            colls.Clear();
        }
    }
}