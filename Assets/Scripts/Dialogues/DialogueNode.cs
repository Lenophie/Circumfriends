using XNode;

namespace Dialogues {
    public abstract class DialogueNode : Node {
        [Input(backingValue = ShowBackingValue.Never)] public DialogueNode input;

        public abstract void Trigger();

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}