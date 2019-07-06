using Constants;

namespace Dialogues.Events {
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