using Dialogues;
using TMPro;
using UnityEngine;

namespace Managers {
    public class DialogueManager {
        private ChatNode currentChatNode;
        private readonly TextMeshProUGUI dialogueTextMesh;
        private readonly Animator dialogueHeadshotAnimator;

        public DialogueManager(TextMeshProUGUI dialogueTextMesh, Animator dialogueHeadshotAnimator) {
            this.dialogueTextMesh = dialogueTextMesh;
            this.dialogueHeadshotAnimator = dialogueHeadshotAnimator;
        }

        public void ChangeCurrentChatNode(ChatNode newChatNode) {
            currentChatNode = newChatNode;
            dialogueTextMesh.SetText(currentChatNode.text);
            dialogueHeadshotAnimator.runtimeAnimatorController = currentChatNode.character.animatorController;
        }
    }
}