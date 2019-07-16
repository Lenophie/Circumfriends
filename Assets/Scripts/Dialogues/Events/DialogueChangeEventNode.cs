using Constants;

namespace Dialogues.Events {
    /**
     * This Node is used to end a dialogue graph by loading another
     */
    [CreateNodeMenu("FinalNodes/DialogueChange")]
    public class DialogueChangeEventNode : EventNode {
        public DialogueChangeEvent dialogueChangeEvent;

        public override void Trigger() {
            ((DialogueGraph) graph).HandleEvent(DialogueEventsEnum.DialogueChange,
                dialogueChangeEvent);
            base.Trigger();
        }
    }
}