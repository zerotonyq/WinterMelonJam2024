using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.U2D;

namespace Test
{
    [RequireComponent(typeof(SpriteShapeController))]
    public class SpriteShapeCircleConstructor : MonoBehaviour
    {
        public SpriteShapeController spriteShapeController;
        public float radius;

        private float _tangentDistance;
        public void OnValidate() => spriteShapeController = GetComponent<SpriteShapeController>();

        [ContextMenu(nameof(SetTang))]
        public void SetTang()
        {
            _tangentDistance = (float)((4.0 / 3) * Math.Tan(Math.PI / (8))) * radius;
            
            spriteShapeController.spline.SetLeftTangent(0, -Vector3.up * _tangentDistance);
            spriteShapeController.spline.SetRightTangent(0, Vector3.up * _tangentDistance);
            spriteShapeController.spline.SetPosition(0, -Vector3.right * radius);
            
            spriteShapeController.spline.SetLeftTangent(1, -Vector3.right * _tangentDistance);
            spriteShapeController.spline.SetRightTangent(1, Vector3.right * _tangentDistance);
            spriteShapeController.spline.SetPosition(1, Vector3.up * radius);
            
            spriteShapeController.spline.SetLeftTangent(2, Vector3.up * _tangentDistance);
            spriteShapeController.spline.SetRightTangent(2, -Vector3.up * _tangentDistance);
            spriteShapeController.spline.SetPosition(2, Vector3.right * radius);
            
            spriteShapeController.spline.SetLeftTangent(3, Vector3.right * _tangentDistance);
            spriteShapeController.spline.SetRightTangent(3, -Vector3.right * _tangentDistance);
            spriteShapeController.spline.SetPosition(3, -Vector3.up * radius);
            
        }
    }
}