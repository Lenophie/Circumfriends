using System.Collections.Generic;
using Characters;
using XNode;

namespace Dialogues {
    [NodeTint("#4d9599")] [CreateNodeMenu("ChatNode")]
    public class ChatNode : DialogueNode {
        public Character character;
        public ChatContent content;
        public float sentenceDurationInSeconds;
        public float totalDurationInSeconds;

        [Output(dynamicPortList = true)]
        public List<ChatNodeConditionsList> continuationConditions = new List<ChatNodeConditionsList>();

        public void PickAnswer(int index) {
            NodePort port = null;

            if (continuationConditions.Count <= index) return;
            port = GetOutputPort(nameof(continuationConditions) + " " + index);
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