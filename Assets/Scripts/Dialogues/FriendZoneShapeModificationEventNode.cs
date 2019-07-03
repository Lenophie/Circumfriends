using Constants;

namespace Dialogues {
    public class FriendZoneShapeModificationEventNode : EventNode {
        public FriendZoneShapeModificationEvent friendZoneShapeModificationEvent;

        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.FriendZoneShapeModification,
                friendZoneShapeModificationEvent);
        }
    }
}