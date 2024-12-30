using System;
using Gameplay.Base;
using Unity.Mathematics;
using UnityEngine;

namespace Gameplay.Movement
{
    [RequireComponent(typeof(Rigidbody2D), typeof(GroundCheckerComponent))]
    public class MovementComponent : MonoBehaviour, IExecutable
    {
        private const float MaxVelocityHorizontal = 20f;
        private const float MaxVelocityVertical = 40f;
        [SerializeField] private float maxSpeedHorizontal = 20f;
        private Rigidbody2D _rigidbody2D;

        private bool _isMoved;
        public float CurrentAcceleration { get; private set; }
        private float _acceleration;

        public void Initialize(int acceleration)
        {
            _acceleration = acceleration;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void StartMoving(bool isRight = true)
        {
            if (!_rigidbody2D)
                return;

            _isMoved = true;
            CurrentAcceleration = isRight ? _acceleration : -_acceleration;
        }

        public void StopMoving()
        {
            _isMoved = false;
            CurrentAcceleration = 0;
        }

        public void Execute()
        {
            var projectionHorizontal = _rigidbody2D.linearVelocity.magnitude *
                                       Mathf.Cos(Mathf.Deg2Rad *
                                                 Vector3.Angle(transform.right, _rigidbody2D.linearVelocity));
            var projectionVertical = _rigidbody2D.linearVelocity.magnitude *
                                     Mathf.Cos(Mathf.Deg2Rad *
                                               Vector3.Angle(transform.up, _rigidbody2D.linearVelocity));
            projectionHorizontal = Mathf.Clamp(projectionHorizontal, -MaxVelocityHorizontal, MaxVelocityHorizontal);
            projectionVertical = Mathf.Clamp(projectionVertical, -MaxVelocityVertical, MaxVelocityVertical);

            _rigidbody2D.linearVelocity = transform.right * projectionHorizontal + transform.up * projectionVertical;
            
            if (!_isMoved )
                return;

            _rigidbody2D.AddForce(transform.right * CurrentAcceleration, ForceMode2D.Force);
        }

        private void OnDrawGizmosSelected()
        {
            if (_rigidbody2D == null)
                return;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)_rigidbody2D.linearVelocity);
        }
    }
}