using Constants;

namespace Dialogues.Events {
    [CreateNodeMenu("FinalNode")]
    public class FinalEventNode : EventNode {
        public FinalEvent finalEvent;

        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.DialogueEnd,
                finalEvent);
            base.Trigger();
        }
    }
}