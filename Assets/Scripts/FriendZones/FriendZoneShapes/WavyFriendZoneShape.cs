using Constants;
using UnityEngine;

namespace FriendZones.FriendZoneShapes {
    /**
     * This FriendZoneShape is a "Wavy circle" as in a sinusoidal line wrapped in a circle
     */
    public class WavyFriendZoneShape : IFriendZoneShape {
        public Vector3[] TargetOuterVertices { get; private set; } // The shape's target outer vertices

        // Aspect characteristics
        private readonly float radius; // The base circle radius
        private readonly float amplitude; // The amplitude of the oscillations
        private readonly float numberOfPeriods; // The number of periods of the sinusoidal

        // Offset
        private float startRad; // The starting angle of the sinusoidal

        // Rotation characteristics
        private readonly bool isRotating; // If true, the shape is rotating
        private readonly bool isClockwise; // If true, the shape rotation is clockwise (if there is a rotation)
        private readonly float rotationSpeed; // The rotation speed (if there is a rotation)

        public WavyFriendZoneShape(WavyFriendZoneShapeConfig wavyFriendZoneShapeConfig) {
            radius = wavyFriendZoneShapeConfig.radius;
            amplitude = wavyFriendZoneShapeConfig.amplitude;
            numberOfPeriods = wavyFriendZoneShapeConfig.numberOfPeriods;

            startRad = wavyFriendZoneShapeConfig.startRad;

            isRotating = wavyFriendZoneShapeConfig.isRotating;
            isClockwise = wavyFriendZoneShapeConfig.isClockwise;
            rotationSpeed = wavyFriendZoneShapeConfig.rotationSpeed;
        }

        // Updates the starting angle of the sinusoid
        private void Rotate() {
            if (isRotating)
                startRad += (isClockwise ? -1 : 1) * rotationSpeed * Time.deltaTime;
        }

        public void CalculateTargetOuterVertices() {
            // Do the rotation
            Rotate();

            // Calculate the new target positions
            Vector3[] positions = new Vector3[FriendZonesConstants.NumberOfOuterVerticesPerFriendzone];
            for (int i = 0; i < FriendZonesConstants.NumberOfOuterVerticesPerFriendzone; i++) {
                float rad = Mathf.Deg2Rad * (i * 360f / FriendZonesConstants.NumberOfOuterVerticesPerFriendzone);
                positions[i] = (1 + amplitude * Mathf.Cos(startRad + rad * numberOfPeriods)) *
                               new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0f);
            }

            // Set the target outer vertices
            TargetOuterVertices = positions;
        }
    }
}