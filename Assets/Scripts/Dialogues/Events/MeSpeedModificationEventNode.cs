using Constants;

namespace Dialogues.Events {
    /**
     * This Node is used to modify the rotational speed of the player
     */
    [CreateNodeMenu("Events/MeSpeedModificationNode")]
    public class MeSpeedModificationEventNode : EventNode {
        public MeSpeedModificationEvent meSpeedModificationEvent;

        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.MeSpeedModification,
                meSpeedModificationEvent);
            base.Trigger();
        }
    }
}