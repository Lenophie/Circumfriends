using System;
using Constants;

namespace FriendZones.FriendZoneShapes {
    [Serializable]
    public class FriendZoneShapeConfigForm {
        public FriendZoneShapesEnum friendZoneShapesEnum;
        public WavyFriendZoneShapeConfig friendZoneShapeConfig;
        //TODO: Use general FriendZoneShapeConfig and cast it as one of its subclass with the help of a custom editor and the enum field

    }
}