namespace FriendZones.FriendZoneShapes {
    public class FriendZoneShapeConfig {
        public readonly float Radius;
        public readonly float Amplitude;
        public readonly float NumberOfPeriods;

        public FriendZoneShapeConfig(float radius, float amplitude, float numberOfPeriods) {
            Radius = radius;
            Amplitude = amplitude;
            NumberOfPeriods = numberOfPeriods;
        }
    }
}