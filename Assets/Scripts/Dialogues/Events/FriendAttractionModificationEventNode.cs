using Constants;

namespace Dialogues.Events {
    [CreateNodeMenu("Events/FriendAttractionModificationNode")]
    public class FriendAttractionModificationEventNode : EventNode {
        public FriendAttractionModificationEvent friendAttractionModificationEvent;

        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.FriendAttractionModification,
                friendAttractionModificationEvent);
            base.Trigger();
        }
    }
}