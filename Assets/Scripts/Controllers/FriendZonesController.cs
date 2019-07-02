using System.Collections.Generic;
using Constants;
using FriendZones;
using FriendZones.FriendZoneShapes;
using Helpers;
using Meshes;
using UnityEngine;

namespace Controllers {
    public class FriendZonesController : MonoBehaviour {
        private QuadZonesTuple<FriendZone> friendZones;

        [SerializeField] private FriendZoneCollector noGoFriendZoneCollector = default;
        [SerializeField] private FriendZoneCollector discomfortFriendZoneCollector = default;
        [SerializeField] private FriendZoneCollector comfortFriendZoneCollector = default;
        [SerializeField] private FriendZoneCollector distantFriendZoneCollector = default;

        public void InitializeFriendZones() {
            // Regroup friendzone collectors
            QuadZonesTuple<FriendZoneCollector> friendZonesCollectors =
                new QuadZonesTuple<FriendZoneCollector>(
                    noGoFriendZoneCollector,
                    discomfortFriendZoneCollector,
                    comfortFriendZoneCollector,
                    distantFriendZoneCollector);

            // Initialize friendzones with collectors' info
            friendZones = new QuadZonesTuple<FriendZone>(
                new FriendZone(
                    FriendZonesEnum.NoGo,
                    new CircularFriendZoneShape(2f),
                    friendZonesCollectors.NoGo),
                new FriendZone(
                    FriendZonesEnum.Discomfort,
                    new CircularFriendZoneShape(4f),
                    friendZonesCollectors.Discomfort),
                new FriendZone(
                    FriendZonesEnum.Comfort,
                    new CircularFriendZoneShape(5f),
                    friendZonesCollectors.Comfort),
                new FriendZone(
                    FriendZonesEnum.Distant,
                    new CircularFriendZoneShape(10f),
                    friendZonesCollectors.Distant)
            );
        }

        private void Update() {
            BuildZone(friendZones.NoGo);
            BuildZone(friendZones.Discomfort);
            BuildZone(friendZones.Comfort);
            BuildZone(friendZones.Distant);
        }

        private void BuildZone(FriendZone friendZone) {
            friendZone.FriendZoneShape.CalculateZoneOuterVertices();

            if (friendZone.LineRenderer) {
                friendZone.LineRenderer.positionCount = FriendZonesConstants.NumberOfOuterVerticesPerFriendzone;
                friendZone.LineRenderer.SetPositions(friendZone.FriendZoneShape.OuterVertices);
            }

            List<Vector2> zonePositions2D = new List<Vector2>();
            for (int i = 0; i < FriendZonesConstants.NumberOfOuterVerticesPerFriendzone; i++)
                zonePositions2D.Add(friendZone.FriendZoneShape.OuterVertices[i]);
            if (friendZone.Collider) friendZone.Collider.points = zonePositions2D.ToArray();

            if (friendZone.FriendZoneEnum == FriendZonesEnum.NoGo) {
                Mesh mesh = new Mesh {vertices = friendZone.FriendZoneShape.OuterVertices};
                int[] triangles = Triangulator.TriangulateConcave(zonePositions2D);
                mesh.triangles = triangles;
                if (friendZone.MeshFilter) friendZone.MeshFilter.mesh = mesh;
            } else {
                Vector3[] previousZonePositions;
                switch (friendZone.FriendZoneEnum) {
                    case FriendZonesEnum.Discomfort:
                        previousZonePositions = friendZones.NoGo.FriendZoneShape.OuterVertices;
                        break;
                    case FriendZonesEnum.Comfort:
                        previousZonePositions = friendZones.Discomfort.FriendZoneShape.OuterVertices;
                        break;
                    case FriendZonesEnum.Distant:
                        previousZonePositions = friendZones.Comfort.FriendZoneShape.OuterVertices;
                        break;
                    default:
                        previousZonePositions = new Vector3[0];
                        break;
                }

                Vector3[] meshPositions = new Vector3[2 * FriendZonesConstants.NumberOfOuterVerticesPerFriendzone];
                for (int i = 0; i < FriendZonesConstants.NumberOfOuterVerticesPerFriendzone; i++) {
                    meshPositions[i] = previousZonePositions[i];
                    meshPositions[FriendZonesConstants.NumberOfOuterVerticesPerFriendzone + i] =
                        friendZone.FriendZoneShape.OuterVertices[i];
                }

                Mesh mesh = new Mesh {
                    vertices = meshPositions,
                    triangles = Triangulator.TriangulateRing(FriendZonesConstants.NumberOfOuterVerticesPerFriendzone)
                };
                if (friendZone.MeshFilter) friendZone.MeshFilter.mesh = mesh;

            }
        }
    }
}
