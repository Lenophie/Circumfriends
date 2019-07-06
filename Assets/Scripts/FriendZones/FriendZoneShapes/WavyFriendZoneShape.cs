using Constants;
using UnityEngine;

namespace FriendZones.FriendZoneShapes {
    public class WavyFriendZoneShape : IFriendZoneShape {
        public Vector3[] TargetOuterVertices { get; private set; }

        // Aspect characteristics
        private float radius;
        private float amplitude;
        private float numberOfPeriods;

        // Offset
        private float startRad;

        // Rotation characteristics
        private readonly bool isRotating;
        private readonly bool isClockwise;
        private readonly float rotationSpeed;

        public WavyFriendZoneShape(WavyFriendZoneShapeConfig wavyFriendZoneShapeConfig) {
            radius = wavyFriendZoneShapeConfig.radius;
            amplitude = wavyFriendZoneShapeConfig.amplitude;
            numberOfPeriods = wavyFriendZoneShapeConfig.numberOfPeriods;

            startRad = wavyFriendZoneShapeConfig.startRad;

            isRotating = wavyFriendZoneShapeConfig.isRotating;
            isClockwise = wavyFriendZoneShapeConfig.isClockwise;
            rotationSpeed = wavyFriendZoneShapeConfig.rotationSpeed;
        }

        private void Rotate() {
            if (isRotating)
                startRad += (isClockwise ? -1 : 1) * rotationSpeed * Time.deltaTime;
        }

        public void CalculateTargetOuterVertices() {
            Rotate();
            Vector3[] positions = new Vector3[FriendZonesConstants.NumberOfOuterVerticesPerFriendzone];

            for (int i = 0; i < FriendZonesConstants.NumberOfOuterVerticesPerFriendzone; i++) {
                float rad = Mathf.Deg2Rad * (i * 360f / FriendZonesConstants.NumberOfOuterVerticesPerFriendzone);
                positions[i] = (1 + amplitude * Mathf.Cos(startRad + rad * numberOfPeriods)) *
                               new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0f);
            }

            TargetOuterVertices = positions;
        }
    }
}