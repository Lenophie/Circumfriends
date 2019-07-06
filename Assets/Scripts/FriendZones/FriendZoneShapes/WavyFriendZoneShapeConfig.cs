using System;

namespace FriendZones.FriendZoneShapes {
    [Serializable]
    public class WavyFriendZoneShapeConfig : FriendZoneShapeConfig {
        public float radius;
        public float amplitude;
        public float numberOfPeriods;
        public float startRad;
        public bool isRotating;
        public bool isClockwise;
        public float rotationSpeed;

        public WavyFriendZoneShapeConfig(float radius, float amplitude, float numberOfPeriods, float startRad,
            bool isRotating, bool isClockwise, float rotationSpeed) {
            this.radius = radius;
            this.amplitude = amplitude;
            this.numberOfPeriods = numberOfPeriods;
            this.startRad = startRad;
            this.isRotating = isRotating;
            this.isClockwise = isClockwise;
            this.rotationSpeed = rotationSpeed;
        }

        public WavyFriendZoneShapeConfig(float radius, float amplitude, float numberOfPeriods, float startRad) {
            this.radius = radius;
            this.amplitude = amplitude;
            this.numberOfPeriods = numberOfPeriods;
            this.startRad = startRad;
            isRotating = false;
            isClockwise = true;
            rotationSpeed = 0f;
        }

        public WavyFriendZoneShapeConfig() {
            radius = 0f;
            amplitude = 0f;
            numberOfPeriods = 0f;
            startRad = 0f;
            isRotating = false;
            isClockwise = true;
            rotationSpeed = 0f;
        }
    }
}