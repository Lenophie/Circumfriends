using Constants;

namespace Dialogues.Events {
    /**
     * This Node is used to end a dialogue graph
     */
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