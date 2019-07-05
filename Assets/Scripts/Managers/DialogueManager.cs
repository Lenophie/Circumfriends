using Dialogues;
using UnityEngine;

namespace Managers {
    public class DialogueManager {
        private ChatNode currentChatNode;

        public void ChangeCurrentChatNode(ChatNode newChatNode) {
            currentChatNode = newChatNode;
            Debug.Log(newChatNode.text);
        }
    }
}