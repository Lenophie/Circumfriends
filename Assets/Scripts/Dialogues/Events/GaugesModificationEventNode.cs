using Constants;

namespace Dialogues.Events {
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