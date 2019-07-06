using Constants;

namespace Dialogues.Events {
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