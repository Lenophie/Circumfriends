using System.Collections.Generic;
using Constants;
using FriendZoneShapes;
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

        private float noGoZoneRadius;
        private float discomfortZoneRadius;
        private float comfortZoneRadius;
        private float distantZoneRadius;

        private Vector3[] noGoZoneOuterVertices;
        private Vector3[] discomfortZoneOuterVertices;
        private Vector3[] comfortZoneOuterVertices;

        private void Start() {
            noGoZoneRadius = 2f;
            discomfortZoneRadius = 4f;
            comfortZoneRadius = 5f;
            distantZoneRadius = 10f;

            // Order is important, as the previous positions are used for the next zone's mesh
            BuildZone(FriendZonesEnum.NoGo);
            BuildZone(FriendZonesEnum.Discomfort);
            BuildZone(FriendZonesEnum.Comfort);
            BuildZone(FriendZonesEnum.Distant);
        }

        private void BuildZone(FriendZonesEnum zoneEnum) {
            float radius = zoneEnum == FriendZonesEnum.NoGo ? noGoZoneRadius :
                zoneEnum == FriendZonesEnum.Discomfort ? discomfortZoneRadius :
                zoneEnum == FriendZonesEnum.Comfort ? comfortZoneRadius : distantZoneRadius;
            IFriendZoneShape zoneShape = new CircularFriendZoneShape(radius);

            Vector3[] zoneOuterVertices = zoneShape.CalculateZoneOuterVertices();

            LineRenderer zoneLineRenderer;
            PolygonCollider2D zoneCollider;
            MeshFilter zoneMeshFilter;

            switch (zoneEnum) {
                case FriendZonesEnum.NoGo:
                    zoneLineRenderer = noGoDiscomfortLimitRenderer;
                    zoneCollider = noGoZoneCollider;
                    zoneMeshFilter = noGoZoneMeshFilter;
                    break;
                case FriendZonesEnum.Discomfort:
                    zoneLineRenderer = discomfortComfortLimitRenderer;
                    zoneCollider = discomfortZoneCollider;
                    zoneMeshFilter = discomfortZoneMeshFilter;
                    break;
                case FriendZonesEnum.Comfort:
                    zoneLineRenderer = comfortDistantLimitRenderer;
                    zoneCollider = comfortZoneCollider;
                    zoneMeshFilter = comfortZoneMeshFilter;
                    break;
                case FriendZonesEnum.Distant:
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
                zoneLineRenderer.positionCount = zoneShape.NumberOfVertices;
                zoneLineRenderer.SetPositions(zoneOuterVertices);
            }

            List<Vector2> zonePositions2D = new List<Vector2>();
            for (int i = 0; i < zoneShape.NumberOfVertices; i++) zonePositions2D.Add(zoneOuterVertices[i]);
            if (zoneCollider) zoneCollider.points = zonePositions2D.ToArray();

            switch (zoneEnum) {
                case FriendZonesEnum.NoGo:
                    noGoZoneOuterVertices = zoneOuterVertices;
                    break;
                case FriendZonesEnum.Discomfort:
                    discomfortZoneOuterVertices = zoneOuterVertices;
                    break;
                case FriendZonesEnum.Comfort:
                    comfortZoneOuterVertices = zoneOuterVertices;
                    break;
                case FriendZonesEnum.Distant:
                    break;
            }

            if (zoneEnum == FriendZonesEnum.NoGo) {
                Mesh mesh = new Mesh {vertices = zoneOuterVertices};
                int[] triangles = Triangulator.TriangulateConcave(zonePositions2D);
                mesh.triangles = triangles;
                if (zoneMeshFilter) zoneMeshFilter.mesh = mesh;
            } else {
                Vector3[] previousZonePositions;
                switch (zoneEnum) {
                    case FriendZonesEnum.Discomfort:
                        previousZonePositions = noGoZoneOuterVertices;
                        break;
                    case FriendZonesEnum.Comfort:
                        previousZonePositions = discomfortZoneOuterVertices;
                        break;
                    case FriendZonesEnum.Distant:
                        previousZonePositions = comfortZoneOuterVertices;
                        break;
                    default:
                        previousZonePositions = new Vector3[0];
                        break;
                }

                Vector3[] meshPositions = new Vector3[2 * zoneShape.NumberOfVertices];
                for (int i = 0; i < zoneShape.NumberOfVertices; i++) {
                    meshPositions[i] = previousZonePositions[i];
                    meshPositions[zoneShape.NumberOfVertices + i] = zoneOuterVertices[i];
                }

                Mesh mesh = new Mesh
                    {vertices = meshPositions, triangles = Triangulator.TriangulateRing(zoneShape.NumberOfVertices)};
                if (zoneMeshFilter) zoneMeshFilter.mesh = mesh;

            }
        }
    }
}
