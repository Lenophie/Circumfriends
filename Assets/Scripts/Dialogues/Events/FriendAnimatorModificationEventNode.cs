using Constants;

namespace Dialogues.Events {
    [CreateNodeMenu("Events/FriendAnimatorModificationEventNode")]
    public class FriendAnimatorModificationEventNode : EventNode {
        public FriendAnimatorModificationEvent friendAnimatorModificationEvent;

        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.FriendAnimatorModification,
                friendAnimatorModificationEvent);
            base.Trigger();
        }
    }
}