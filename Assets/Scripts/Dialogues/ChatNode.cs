using System.Collections.Generic;
using Characters;
using XNode;

namespace Dialogues {
    [NodeTint("#4d9599")]
    public class ChatNode : DialogueNode {
        public Character character;
        public ChatContent content;
        [Output(dynamicPortList = true)] public List<string> answers = new List<string>();

        public void PickAnswer(int index) {
            NodePort port = null;

            if (answers.Count <= index) return;
            port = GetOutputPort("answers " + index);
            if (port == null) return;

            for (int i = 0; i < port.ConnectionCount; i++) {
                NodePort connection = port.GetConnection(i);
                ((DialogueNode) connection.node).Trigger();
            }
        }

        public override void Trigger() {
            ((DialogueGraph) graph).HandleChatNodeChange(this);
        }
    }
}