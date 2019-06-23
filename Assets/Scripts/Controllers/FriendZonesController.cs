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

        private int lineNumberOfVertices;
        private float noGoZoneRadius;
        private float discomfortZoneRadius;
        private float comfortZoneRadius;
        private float distantZoneRadius;

        private Vector3[] noGoZoneOuterVertices;
        private Vector3[] discomfortZoneOuterVertices;
        private Vector3[] comfortZoneOuterVertices;

        private void Start() {
            lineNumberOfVertices = 200;
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

        private Vector3[] CalculateZoneOuterVertices(FriendZones zone) {
            float radius = zone == FriendZones.NoGo ? noGoZoneRadius :
                zone == FriendZones.Discomfort ? discomfortZoneRadius :
                zone == FriendZones.Comfort ? comfortZoneRadius : distantZoneRadius;

            Vector3[] positions = new Vector3[lineNumberOfVertices];

            for (int i = 0; i < lineNumberOfVertices; i++) {
                float rad = Mathf.Deg2Rad * (i * 360f / lineNumberOfVertices);
                positions[i] = new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0f);
            }

            return positions;
        }

        private void BuildZone(FriendZones zone) {
            Vector3[] zoneOuterVertices = CalculateZoneOuterVertices(zone);

            LineRenderer zoneLineRenderer;
            PolygonCollider2D zoneCollider;
            MeshFilter zoneMeshFilter;

            switch (zone) {
                case FriendZones.NoGo:
                    zoneLineRenderer = noGoDiscomfortLimitRenderer;
                    zoneCollider = noGoZoneCollider;
                    zoneMeshFilter = noGoZoneMeshFilter;
                    break;
                case FriendZones.Discomfort:
                    zoneLineRenderer = discomfortComfortLimitRenderer;
                    zoneCollider = discomfortZoneCollider;
                    zoneMeshFilter = discomfortZoneMeshFilter;
                    break;
                case FriendZones.Comfort:
                    zoneLineRenderer = comfortDistantLimitRenderer;
                    zoneCollider = comfortZoneCollider;
                    zoneMeshFilter = comfortZoneMeshFilter;
                    break;
                case FriendZones.Distant:
                    zoneLineRenderer = null;
                    zoneCollider = distantZoneCollider;
                    zoneMeshFilter = distantZoneMeshFilter;
                    break;
                default:
                    zoneLineRenderer = null;
                    zoneCollider = null;
                    zoneMeshFilter = null;
                    break;
            }

            if (zoneLineRenderer) {
                zoneLineRenderer.positionCount = lineNumberOfVertices;
                zoneLineRenderer.SetPositions(zoneOuterVertices);
            }

            List<Vector2> zonePositions2D = new List<Vector2>();
            for (int i = 0; i < lineNumberOfVertices; i++) zonePositions2D.Add(zoneOuterVertices[i]);
            if (zoneCollider) zoneCollider.points = zonePositions2D.ToArray();

            switch (zone) {
                case FriendZones.NoGo:
                    noGoZoneOuterVertices = zoneOuterVertices;
                    break;
                case FriendZones.Discomfort:
                    discomfortZoneOuterVertices = zoneOuterVertices;
                    break;
                case FriendZones.Comfort:
                    comfortZoneOuterVertices = zoneOuterVertices;
                    break;
                case FriendZones.Distant:
                    break;
            }

            if (zone == FriendZones.NoGo) {
                Mesh mesh = new Mesh {vertices = zoneOuterVertices};
                int[] triangles = Triangulator.TriangulateConcave(zonePositions2D);
                mesh.triangles = triangles;
                if (zoneMeshFilter) zoneMeshFilter.mesh = mesh;
            } else {
                Vector3[] previousZonePositions;
                switch (zone) {
                    case FriendZones.Discomfort:
                        previousZonePositions = noGoZoneOuterVertices;
                        break;
                    case FriendZones.Comfort:
                        previousZonePositions = discomfortZoneOuterVertices;
                        break;
                    case FriendZones.Distant:
                        previousZonePositions = comfortZoneOuterVertices;
                        break;
                    default:
                        previousZonePositions = new Vector3[0];
                        break;
                }

                Vector3[] meshPositions = new Vector3[2 * lineNumberOfVertices];
                for (int i = 0; i < lineNumberOfVertices; i++) {
                    meshPositions[i] = previousZonePositions[i];
                    meshPositions[lineNumberOfVertices + i] = zoneOuterVertices[i];
                }

                Mesh mesh = new Mesh {vertices = meshPositions, triangles = Triangulator.TriangulateRing(lineNumberOfVertices)};
                if (zoneMeshFilter) zoneMeshFilter.mesh = mesh;

            }
        }
    }
}
