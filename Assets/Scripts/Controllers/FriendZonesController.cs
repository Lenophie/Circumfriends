using System.Collections.Generic;
using Constants;
using Meshes;
using UnityEngine;

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

        [Header("Meshes")]
        [SerializeField] private MeshFilter noGoZoneMeshFilter = default;
        [SerializeField] private MeshFilter discomfortZoneMeshFilter = default;
        [SerializeField] private MeshFilter comfortZoneMeshFilter = default;
        [SerializeField] private MeshFilter distantZoneMeshFilter = default;

        private int points;
        private float noGoZoneRadius;
        private float discomfortZoneRadius;
        private float comfortZoneRadius;
        private float distantZoneRadius;

        private Vector3[] noGoZonePositions;
        private Vector3[] discomfortZonePositions;
        private Vector3[] comfortZonePositions;

        private void Start() {
            points = 200;
            noGoZoneRadius = 2f;
            discomfortZoneRadius = 4f;
            comfortZoneRadius = 5f;
            distantZoneRadius = 10f;

            // Order is important, as the previous positions are used for the next zone's mesh
            BuildZone(FriendZones.NoGo);
            BuildZone(FriendZones.Discomfort);
            BuildZone(FriendZones.Comfort);
            BuildZone(FriendZones.Distant);
        }

        private Vector3[] CalculateZonePositions(FriendZones zone) {
            float radius = zone == FriendZones.NoGo ? noGoZoneRadius :
                zone == FriendZones.Discomfort ? discomfortZoneRadius :
                zone == FriendZones.Comfort ? comfortZoneRadius : distantZoneRadius;

            Vector3[] positions = new Vector3[points];

            for (int i = 0; i < points; i++) {
                float rad = Mathf.Deg2Rad * (i * 360f / points);
                positions[i] = new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0f);
            }

            return positions;
        }

        private void BuildZone(FriendZones zone) {
            Vector3[] zonePositions = CalculateZonePositions(zone);

            LineRenderer lineRenderer;
            PolygonCollider2D zoneCollider;
            MeshFilter zoneMeshFilter;

            switch (zone) {
                case FriendZones.NoGo:
                    lineRenderer = noGoDiscomfortLimitRenderer;
                    zoneCollider = noGoZoneCollider;
                    zoneMeshFilter = noGoZoneMeshFilter;
                    break;
                case FriendZones.Discomfort:
                    lineRenderer = discomfortComfortLimitRenderer;
                    zoneCollider = discomfortZoneCollider;
                    zoneMeshFilter = discomfortZoneMeshFilter;
                    break;
                case FriendZones.Comfort:
                    lineRenderer = comfortDistantLimitRenderer;
                    zoneCollider = comfortZoneCollider;
                    zoneMeshFilter = comfortZoneMeshFilter;
                    break;
                case FriendZones.Distant:
                    lineRenderer = null;
                    zoneCollider = distantZoneCollider;
                    zoneMeshFilter = distantZoneMeshFilter;
                    break;
                default:
                    lineRenderer = null;
                    zoneCollider = null;
                    zoneMeshFilter = null;
                    break;
            }

            if (lineRenderer) {
                lineRenderer.positionCount = points;
                lineRenderer.SetPositions(zonePositions);
            }

            List<Vector2> zonePositions2D = new List<Vector2>();
            for (int i = 0; i < points; i++) zonePositions2D.Add(zonePositions[i]);
            if (zoneCollider) zoneCollider.points = zonePositions2D.ToArray();

            switch (zone) {
                case FriendZones.NoGo:
                    noGoZonePositions = zonePositions;
                    break;
                case FriendZones.Discomfort:
                    discomfortZonePositions = zonePositions;
                    break;
                case FriendZones.Comfort:
                    comfortZonePositions = zonePositions;
                    break;
                case FriendZones.Distant:
                    break;
            }

            if (zone == FriendZones.NoGo) {
                Mesh mesh = new Mesh {vertices = zonePositions};
                int[] triangles = Triangulator.TriangulateConcave(zonePositions2D);
                mesh.triangles = triangles;
                if (zoneMeshFilter) zoneMeshFilter.mesh = mesh;
            } else {
                Vector3[] previousZonePositions;
                switch (zone) {
                    case FriendZones.Discomfort:
                        previousZonePositions = noGoZonePositions;
                        break;
                    case FriendZones.Comfort:
                        previousZonePositions = discomfortZonePositions;
                        break;
                    case FriendZones.Distant:
                        previousZonePositions = comfortZonePositions;
                        break;
                    default:
                        previousZonePositions = new Vector3[0];
                        break;
                }

                Vector3[] meshPositions = new Vector3[2 * points];
                for (int i = 0; i < points; i++) {
                    meshPositions[i] = previousZonePositions[i];
                    meshPositions[points + i] = zonePositions[i];
                }

                Mesh mesh = new Mesh {vertices = meshPositions, triangles = Triangulator.TriangulateRing(points)};
                if (zoneMeshFilter) zoneMeshFilter.mesh = mesh;

            }
        }
    }
}
