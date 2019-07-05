using Constants;
using Dialogues;
using TMPro;
using UnityEngine;

namespace Managers {
    public class DialogueManager {
        private ChatNode currentChatNode;
        private readonly LanguagesEnum language;
        private readonly TextMeshProUGUI dialogueTextMesh;
        private readonly Animator dialogueHeadshotAnimator;

        public DialogueManager(TextMeshProUGUI dialogueTextMesh, Animator dialogueHeadshotAnimator,
            LanguagesEnum language) {
            this.dialogueTextMesh = dialogueTextMesh;
            this.dialogueHeadshotAnimator = dialogueHeadshotAnimator;
            this.language = language;
        }

        public void ChangeCurrentChatNode(ChatNode newChatNode) {
            currentChatNode = newChatNode;
            string currentChatNodeContent = GetCurrentChatNodeContent();
            dialogueTextMesh.SetText(currentChatNodeContent);
            dialogueHeadshotAnimator.runtimeAnimatorController = currentChatNode.character.animatorController;
        }

        private string GetCurrentChatNodeContent() {
            return language == LanguagesEnum.English ? currentChatNode.content.englishText :
                language == LanguagesEnum.French ? currentChatNode.content.frenchText : "";
        }
    }
}