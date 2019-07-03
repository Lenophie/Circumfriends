using System;

namespace FriendZones.FriendZoneShapes {
    [Serializable]
    public class FriendZoneShapeConfig {
        public float radius;
        public float amplitude;
        public float numberOfPeriods;

        public FriendZoneShapeConfig(float radius, float amplitude, float numberOfPeriods) {
            this.radius = radius;
            this.amplitude = amplitude;
            this.numberOfPeriods = numberOfPeriods;
        }
    }
}