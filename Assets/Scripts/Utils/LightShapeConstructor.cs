using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Utils
{
    [RequireComponent(typeof(Light2D))]
    public class LightShapeConstructor : MonoBehaviour
    {
        public Light2D light2D;
        public float radius;
        public void OnValidate() => light2D = GetComponent<Light2D>();

        [ContextMenu(nameof(SetTang))]
        public void SetTang()
        {
            var path = new List<Vector3>();
            for (var i = 0; i < 180; ++i)
            {
                var v = new Vector2(Mathf.Cos(Mathf.PI  / 180 * i), Mathf.Sin(Mathf.PI  / 180 * i)) * radius;
                path.Add(v);    
            }
            
            light2D.SetShapePath(path.ToArray());
        }
    }
}