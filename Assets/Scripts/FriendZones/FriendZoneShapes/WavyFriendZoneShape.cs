using Constants;
using UnityEngine;

namespace FriendZones.FriendZoneShapes {
    public class WavyFriendZoneShape : IFriendZoneShape {
        public Vector3[] OuterVertices { get; private set; }
        private float radius;
        private float amplitude;
        private float numberOfPeriods;
        private float startRad;
        private bool isRotating;
        private bool isClockwise;
        private float rotationSpeed;

        public WavyFriendZoneShape(float radius, float amplitude, float numberOfPeriods, float startRad) {
            this.startRad = 0f;
            this.radius = radius;
            this.amplitude = amplitude;
            this.numberOfPeriods = numberOfPeriods;
            this.startRad = startRad;
            isRotating = false;
            isClockwise = true;
            rotationSpeed = 0f;
        }

        public WavyFriendZoneShape(float radius, float amplitude, float numberOfPeriods, float startRad,
            bool isRotating, bool isClockwise, float rotationSpeed) {
            this.startRad = 0f;
            this.radius = radius;
            this.amplitude = amplitude;
            this.numberOfPeriods = numberOfPeriods;
            this.startRad = startRad;
            this.isRotating = isRotating;
            this.isClockwise = isClockwise;
            this.rotationSpeed = rotationSpeed;
        }

        private void Rotate() {
            if (isRotating)
                startRad += (isClockwise ? -1 : 1) * rotationSpeed * Time.deltaTime;
        }

        public void EnableRotation(bool shouldRotate) {
            isRotating = shouldRotate;
        }

        public void CalculateZoneOuterVertices() {
            Vector3[] positions = new Vector3[FriendZonesConstants.NumberOfOuterVerticesPerFriendzone];

            Rotate();
            for (int i = 0; i < FriendZonesConstants.NumberOfOuterVerticesPerFriendzone; i++) {
                float rad = Mathf.Deg2Rad * (i * 360f / FriendZonesConstants.NumberOfOuterVerticesPerFriendzone);
                positions[i] = (1 + amplitude * Mathf.Cos(startRad + rad * numberOfPeriods)) *
                               new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0f);
            }

            OuterVertices = positions;
        }
    }
}