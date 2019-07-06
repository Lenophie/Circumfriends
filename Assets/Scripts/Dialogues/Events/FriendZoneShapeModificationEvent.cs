using System;
using Constants;
using FriendZones.FriendZoneShapes;

namespace Dialogues.Events {
    [Serializable]
    public class FriendZoneShapeModificationEvent : DialogueEvent {
        public FriendZonesEnum friendZonesEnum;
        public FriendZoneShapeConfigForm friendZoneShapeConfigForm;
    }
}