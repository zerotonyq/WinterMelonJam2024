using UnityEngine;

namespace Gameplay.Planet
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class Planet : MonoBehaviour
    {
        public Vector3 Center => transform.position;
        public float Radius => GetComponent<CircleCollider2D>().bounds.size.x / 2;
        
        public Vector2 GetPointOnPlanet(float angleCounterClockwise)
        {
            var rads = Mathf.Deg2Rad * angleCounterClockwise;

            var normal = new Vector2(Mathf.Cos(rads), Mathf.Sin(rads));

            return Center + (Vector3)(normal.normalized * GetComponent<CircleCollider2D>().bounds.size / 2) +
                   (Vector3)(normal.normalized);
        }

        public (Vector2 position, float pointAngle) GetPointOnPlanet(float initAngle, float hordeLength,
            bool isCounterClockwise = true)
        {
            var angle = Mathf.Asin(hordeLength / 2 / Radius) * Mathf.Rad2Deg * 2;

            var resAngle = isCounterClockwise ? initAngle - angle : initAngle + angle;
            
            return (GetPointOnPlanet(resAngle), resAngle);
        }
    }
}