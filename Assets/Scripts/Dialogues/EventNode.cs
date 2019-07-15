using XNode;

namespace Dialogues {
    /**
     * This abstract class determines the basic functions of an event Node :
     * * Possession of an output port
     * * Implementation of the Trigger method to chain triggers through EventNodes
     */
    [NodeTint("#ad74b0")]
    public abstract class EventNode : DialogueNode {
        [Output] public float output;

        public override void Trigger() {
            NodePort port = GetOutputPort("output");
            if (port == null) return;

            for (int i = 0; i < port.ConnectionCount; i++) {
                NodePort connection = port.GetConnection(i);
                ((DialogueNode) connection.node).Trigger();
            }
        }
    }
}