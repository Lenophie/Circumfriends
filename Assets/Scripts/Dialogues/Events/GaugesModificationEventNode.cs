using Constants;

namespace Dialogues.Events {
    /**
     * This Node is used to modify the gauges
     */
    [CreateNodeMenu("Events/GaugesModificationEventNode")]
    public class GaugesModificationEventNode : EventNode {
        public GaugesModificationEvent gaugesModificationEvent;

        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.GaugesModification,
                gaugesModificationEvent);
            base.Trigger();
        }
    }
}