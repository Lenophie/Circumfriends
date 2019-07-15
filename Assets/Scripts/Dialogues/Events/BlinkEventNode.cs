using Constants;

namespace Dialogues.Events {
    /**
     * This Node is used to make a given FriendZone blink
     */
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