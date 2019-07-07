using Constants;

namespace Dialogues.Events {
    [CreateNodeMenu("Events/BlinkEventNode")]
    public class BlinkEventNode : EventNode {
        public BlinkEvent blinkEvent;

        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.Blink,
                blinkEvent);
            base.Trigger();
        }
    }
}