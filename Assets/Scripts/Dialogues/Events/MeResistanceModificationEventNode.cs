using Constants;

namespace Dialogues.Events {
    /**
     * This Node is used to modify the strength of the resistance of the player to the Friend's pull
     */
    [CreateNodeMenu("Events/MeResistanceModificationNode")]
    public class MeResistanceModificationEventNode : EventNode {
        public MeResistanceModificationEvent meResistanceModificationEvent;

        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.MeResistanceModification,
                meResistanceModificationEvent);
            base.Trigger();
        }
    }
}