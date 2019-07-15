using Constants;

namespace Dialogues.Events {
    /**
     * This Node is used to change the shape of a FriendZone
     */
    [CreateNodeMenu("Events/FriendZoneShapeModificationNode")]
    public class FriendZoneShapeModificationEventNode : EventNode {
        public FriendZoneShapeModificationEvent friendZoneShapeModificationEvent;

        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.FriendZoneShapeModification,
                friendZoneShapeModificationEvent);
            base.Trigger();
        }
    }
}