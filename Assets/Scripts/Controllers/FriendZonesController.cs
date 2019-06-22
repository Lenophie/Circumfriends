using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers {
    public class FriendZonesController : MonoBehaviour {
        [Header("Limit Renderers")]
        [SerializeField] private LineRenderer noGoDiscomfortLimitRenderer = default;
        [SerializeField] private LineRenderer discomfortComfortLimitRenderer = default;
        [SerializeField] private LineRenderer comfortDistantLimitRenderer = default;

        [Header("Colliders")]
        [SerializeField] private PolygonCollider2D noGoZoneCollider = default;
        [SerializeField] private PolygonCollider2D discomfortZoneCollider = default;
        [SerializeField] private PolygonCollider2D comfortZoneCollider = default;
        [SerializeField] private PolygonCollider2D distantZoneCollider = default;

        private int points;
        private float noGoZoneRadius;
        private float discomfortZoneRadius;
        private float comfortZoneRadius;
        private float distantZoneRadius;

        private enum Zones {
            NoGo,
            Discomfort,
            Comfort,
            Distant
        }
        private void Start() {
            points = 200;
            noGoZoneRadius = 2f;
            discomfortZoneRadius = 4f;
            comfortZoneRadius = 5f;
            distantZoneRadius = 10f;

            BuildZone(Zones.NoGo);
            BuildZone(Zones.Discomfort);
            BuildZone(Zones.Comfort);
            BuildZone(Zones.Distant);
        }

        private Vector3[] CalculateZonePositions(Zones zone) {
            float radius = zone == Zones.NoGo ? noGoZoneRadius :
                zone == Zones.Discomfort ? discomfortZoneRadius :
                zone == Zones.Comfort ? comfortZoneRadius : distantZoneRadius;

            Vector3[] positions = new Vector3[points];

            for (int i = 0; i < points; i++) {
                float rad = Mathf.Deg2Rad * (i * 360f / points);
                positions[i] = new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0f);
            }

            return positions;
        }

        private void BuildZone(Zones zone) {
            Vector3[] positions = CalculateZonePositions(zone);
            LineRenderer lineRenderer = zone == Zones.NoGo ? noGoDiscomfortLimitRenderer :
                zone == Zones.Discomfort ? discomfortComfortLimitRenderer :
                zone == Zones.Comfort ? comfortDistantLimitRenderer : null;
            PolygonCollider2D zoneCollider = zone == Zones.NoGo ? noGoZoneCollider :
                zone == Zones.Discomfort ? discomfortZoneCollider :
                zone == Zones.Comfort ? comfortZoneCollider : distantZoneCollider;

            if (lineRenderer) {
                lineRenderer.positionCount = points;
                lineRenderer.SetPositions(positions);
            }

            Vector2[] positions2D = new Vector2[points];
            for (int i = 0; i < points; i++) positions2D[i] = positions[i];
            zoneCollider.points = positions2D;
        }
    }
}
