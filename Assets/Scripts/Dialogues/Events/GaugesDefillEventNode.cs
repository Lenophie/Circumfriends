using Constants;

namespace Dialogues.Events {
    /**
     * This Node is used to empty the gauges
     */
    [CreateNodeMenu("Events/GaugesDefillEventNode")]
    public class GaugesDefillEventNode : EventNode {
        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.GaugesDefill, null);
            base.Trigger();
        }
    }
}