using Constants;

namespace Dialogues.Events {
    [CreateNodeMenu("Events/InputEnablingEventNode")]
    public class InputsEnablingEventNode : EventNode {
        public InputsEnablingEvent inputsEnablingEvent;

        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.InputsEnabling,
                inputsEnablingEvent);
            base.Trigger();
        }
    }
}