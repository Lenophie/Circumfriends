using XNode;

namespace Dialogues {
    /**
     * This abstract class defines the base Node for every Node used in DialogueGraphs
     */
    public abstract class DialogueNode : Node {
        [Input(backingValue = ShowBackingValue.Never)] public DialogueNode input;

        public abstract void Trigger();

        public override object GetValue(NodePort port) {
            return null;
        }
    }
}