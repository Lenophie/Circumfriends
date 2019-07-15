using Constants;

namespace Dialogues.Events {
    /**
     * This Node is used to change the strength of the attraction of the Friend
     */
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