using Constants;
using UnityEngine;

namespace FriendZones.FriendZoneShapes {
    public class CircularFriendZoneShape : IFriendZoneShape {
        public Vector3[] OuterVertices { get; private set; }
        private float radius;

        public CircularFriendZoneShape(float radius) {
            this.radius = radius;
        }

        public void CalculateZoneOuterVertices() {
            Vector3[] positions = new Vector3[FriendZonesConstants.NumberOfOuterVerticesPerFriendzone];

            for (int i = 0; i < FriendZonesConstants.NumberOfOuterVerticesPerFriendzone; i++) {
                float rad = Mathf.Deg2Rad * (i * 360f / FriendZonesConstants.NumberOfOuterVerticesPerFriendzone);
                positions[i] = new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0f);
            }

            OuterVertices = positions;
        }
    }
}