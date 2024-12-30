using System;
using UnityEngine;

namespace Gameplay.Core.Rotation
{
    public class GravitationRotationComponent : MonoBehaviour
    {
        private Vector3 _center;
        
        public void Initialize(Vector3 center) => _center = center;

        public void FixedUpdate()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - _center , -Vector3.forward) * Quaternion.Euler(90,0,0);
        }

    }
}