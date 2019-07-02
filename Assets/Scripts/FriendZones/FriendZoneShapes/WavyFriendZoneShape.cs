using Constants;
using UnityEngine;

namespace FriendZones.FriendZoneShapes {
    public class WavyFriendZoneShape : IFriendZoneShape {
        public Vector3[] OuterVertices { get; private set; }
        // Aspect characteristics
        private float radius;
        private float amplitude;
        private float numberOfPeriods;

        // Offset
        private float startRad;

        // Rotation characteristics
        private bool isRotating;
        private bool isClockwise;
        private float rotationSpeed;

        // Transition characteristics
        private bool isTransitioning;
        private Vector3[] transitionTargetVertices;

        public WavyFriendZoneShape(float radius, float amplitude, float numberOfPeriods, float startRad) {
            this.radius = radius;
            this.amplitude = amplitude;
            this.numberOfPeriods = numberOfPeriods;

            this.startRad = startRad;

            isRotating = false;
            isClockwise = true;
            rotationSpeed = 0f;

            isTransitioning = false;
        }

        public WavyFriendZoneShape(float radius, float amplitude, float numberOfPeriods, float startRad,
            bool isRotating, bool isClockwise, float rotationSpeed) {
            this.radius = radius;
            this.amplitude = amplitude;
            this.numberOfPeriods = numberOfPeriods;

            this.startRad = startRad;

            this.isRotating = isRotating;
            this.isClockwise = isClockwise;
            this.rotationSpeed = rotationSpeed;

            isTransitioning = false;
        }

        private void Rotate() {
            if (isRotating)
                startRad += (isClockwise ? -1 : 1) * rotationSpeed * Time.deltaTime;
        }

        public void EnableRotation(bool shouldRotate) {
            isRotating = shouldRotate;
        }

        public void CalculateZoneOuterVertices() {
            Rotate();
            CalculateTargetOuterVertices();
            if (!isTransitioning) OuterVertices = transitionTargetVertices;
            else {
                Vector3[] lerpedPositions = new Vector3[FriendZonesConstants.NumberOfOuterVerticesPerFriendzone];

                for (int i = 0; i < FriendZonesConstants.NumberOfOuterVerticesPerFriendzone; i++)
                    lerpedPositions[i] = new Vector3(
                        Mathf.Lerp(OuterVertices[i].x, transitionTargetVertices[i].x, Time.deltaTime),
                        Mathf.Lerp(OuterVertices[i].y, transitionTargetVertices[i].y, Time.deltaTime),
                        0f);

                OuterVertices = lerpedPositions;
            }
        }

        private void CalculateTargetOuterVertices() {
            Vector3[] positions = new Vector3[FriendZonesConstants.NumberOfOuterVerticesPerFriendzone];

            for (int i = 0; i < FriendZonesConstants.NumberOfOuterVerticesPerFriendzone; i++) {
                float rad = Mathf.Deg2Rad * (i * 360f / FriendZonesConstants.NumberOfOuterVerticesPerFriendzone);
                positions[i] = (1 + amplitude * Mathf.Cos(startRad + rad * numberOfPeriods)) *
                               new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0f);
            }

            transitionTargetVertices = positions;
        }

        public void TransitionToNewCharacteristics(FriendZoneShapeConfig friendZoneShapeConfig) {
            isTransitioning = true;
            radius = friendZoneShapeConfig.Radius;
            amplitude = friendZoneShapeConfig.Amplitude;
            numberOfPeriods = friendZoneShapeConfig.NumberOfPeriods;
        }
    }
}