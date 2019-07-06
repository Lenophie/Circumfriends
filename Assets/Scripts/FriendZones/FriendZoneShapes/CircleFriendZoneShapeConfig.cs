using System;

namespace FriendZones.FriendZoneShapes {
    [Serializable]
    public class CircleFriendZoneShapeConfig : WavyFriendZoneShapeConfig {
        public CircleFriendZoneShapeConfig(float radius) {
            this.radius = radius;
        }
    }
}