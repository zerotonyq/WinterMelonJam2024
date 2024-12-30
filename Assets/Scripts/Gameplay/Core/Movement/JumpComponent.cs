using Gameplay.Base;
using UnityEngine;

namespace Gameplay.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class JumpComponent : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        
        private bool _isAllowedJump;
        private float _jumpForce;
        
        public void Initialize(float jumpForce)
        {
            _jumpForce = jumpForce;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void JumpAllowed(bool isAllowed)
        {
            
            _isAllowedJump = isAllowed;
        }


        public void Jump()
        {
            if (!_isAllowedJump)
                return; 
            
            _rigidbody2D.AddForce(transform.up *  _jumpForce, ForceMode2D.Impulse);
        }
    }
}