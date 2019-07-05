using Dialogues;
using TMPro;
using UnityEngine;

namespace Managers {
    public class DialogueManager {
        private ChatNode currentChatNode;
        private TextMeshProUGUI dialogueTextMesh;

        public DialogueManager(TextMeshProUGUI dialogueTextMesh) {
            this.dialogueTextMesh = dialogueTextMesh;
        }

        public void ChangeCurrentChatNode(ChatNode newChatNode) {
            currentChatNode = newChatNode;
            dialogueTextMesh.SetText(currentChatNode.text);
        }
    }
}