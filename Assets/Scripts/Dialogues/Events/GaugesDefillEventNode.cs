using Constants;

namespace Dialogues.Events {
    [CreateNodeMenu("Events/GaugesDefillEventNode")]
    public class GaugesDefillEventNode : EventNode {
        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.GaugesDefill, null);
            base.Trigger();
        }
    }
}