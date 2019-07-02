using UnityEngine;

namespace FriendZones.FriendZoneShapes {
    public class CircularFriendZoneShape : IFriendZoneShape {
        public int NumberOfVertices { get; }
        public Vector3[] OuterVertices { get; private set; }
        public float Radius { get; }

        public CircularFriendZoneShape(float radius) {
            Radius = radius;
            NumberOfVertices = 200;
        }

        public void CalculateZoneOuterVertices() {
            Vector3[] positions = new Vector3[NumberOfVertices];

            for (int i = 0; i < NumberOfVertices; i++) {
                float rad = Mathf.Deg2Rad * (i * 360f / NumberOfVertices);
                positions[i] = new Vector3(Mathf.Sin(rad) * Radius, Mathf.Cos(rad) * Radius, 0f);
            }

            OuterVertices = positions;
        }
    }
}