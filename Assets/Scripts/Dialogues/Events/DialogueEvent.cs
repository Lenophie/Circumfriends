using System;
using Constants;
using FriendZones.FriendZoneShapes;

namespace Dialogues.Events {
    public abstract class DialogueEvent {}

    [Serializable]
    public class FriendZoneShapeModificationEvent : DialogueEvent {
        public FriendZonesEnum friendZonesEnum;
        public FriendZoneShapeConfig friendZoneShapeConfig;
    }
}