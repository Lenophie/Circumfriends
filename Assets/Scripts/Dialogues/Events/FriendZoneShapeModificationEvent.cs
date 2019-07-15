using System;
using Constants;
using FriendZones.FriendZoneShapes;

namespace Dialogues.Events {
    /**
     * This class serializes a change of shape for a given FriendZone
     */
    [Serializable]
    public class FriendZoneShapeModificationEvent : DialogueEvent {
        public FriendZonesEnum friendZonesEnum; // The FriendZone whose shape will be modified
        public FriendZoneShapeConfigForm friendZoneShapeConfigForm; // The configuration of the new shape
    }
}