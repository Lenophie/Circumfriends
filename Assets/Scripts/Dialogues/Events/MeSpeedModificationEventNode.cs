using Constants;

namespace Dialogues.Events {
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