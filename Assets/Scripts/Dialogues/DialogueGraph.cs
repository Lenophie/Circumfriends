using System.Linq;
using UnityEngine;
using XNode;

namespace Dialogues {
    [CreateAssetMenu(menuName = "Dialogue/Graph")]
    public class DialogueGraph : NodeGraph {
        [HideInInspector] public ChatNode currentChatNode;

        public void Restart() {
            //Find the first DialogueNode without any inputs. This is the starting node.
            currentChatNode = nodes.Find(x => x is ChatNode && x.Inputs.All(y => !y.IsConnected)) as ChatNode;
        }

        public void PickAnswerToCurrentChatNode(int index) {
            if (currentChatNode) currentChatNode.PickAnswer(index);
        }
    }
}