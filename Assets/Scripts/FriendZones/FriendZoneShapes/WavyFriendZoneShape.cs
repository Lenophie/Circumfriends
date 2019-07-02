using Constants;
using UnityEngine;

namespace FriendZones.FriendZoneShapes {
    public class WavyFriendZoneShape : IFriendZoneShape {
        public Vector3[] OuterVertices { get; private set; }
        private float radius;
        private float amplitude;
        private float numberOfPeriods;

        public WavyFriendZoneShape(float radius, float amplitude, float numberOfPeriods) {
            this.radius = radius;
            this.amplitude = amplitude;
            this.numberOfPeriods = numberOfPeriods;
        }

        public void CalculateZoneOuterVertices() {
            Vector3[] positions = new Vector3[FriendZonesConstants.NumberOfOuterVerticesPerFriendzone];

            for (int i = 0; i < FriendZonesConstants.NumberOfOuterVerticesPerFriendzone; i++) {
                float rad = Mathf.Deg2Rad * (i * 360f / FriendZonesConstants.NumberOfOuterVerticesPerFriendzone);
                positions[i] = (1 + amplitude * Mathf.Cos(rad * numberOfPeriods)) *
                               new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0f);
            }

            OuterVertices = positions;
        }
    }
}