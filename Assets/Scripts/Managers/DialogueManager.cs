using System.Collections;
using Constants;
using Dialogues;
using TMPro;
using UnityEngine;

namespace Managers {
    public class DialogueManager {
        private ChatNode currentChatNode;
        private readonly GameManager gameManager;
        private readonly LanguagesEnum language;
        private readonly TextMeshProUGUI dialogueTextMesh;
        private readonly Animator dialogueHeadshotAnimator;

        public DialogueManager(TextMeshProUGUI dialogueTextMesh, Animator dialogueHeadshotAnimator,
            LanguagesEnum language, GameManager gameManager) {
            this.dialogueTextMesh = dialogueTextMesh;
            this.dialogueHeadshotAnimator = dialogueHeadshotAnimator;
            this.language = language;
            this.gameManager = gameManager;
        }

        public void ChangeCurrentChatNode(ChatNode newChatNode) {
            currentChatNode = newChatNode;
            string currentChatNodeContent = GetCurrentChatNodeContent();
            gameManager.StopAllCoroutines();
            gameManager.StartCoroutine(TypeText(currentChatNodeContent, currentChatNode.durationInSeconds));
            dialogueHeadshotAnimator.runtimeAnimatorController = currentChatNode.character.animatorController;
        }

        private string GetCurrentChatNodeContent() {
            return language == LanguagesEnum.English ? currentChatNode.content.englishText :
                language == LanguagesEnum.French ? currentChatNode.content.frenchText : "";
        }

        private IEnumerator TypeText(string text, float totalDuration) {
            string typedText = "";
            float durationByLetter = totalDuration / text.Length;
            dialogueTextMesh.SetText(typedText);
            foreach (char letter in text.ToCharArray()) {
                typedText += letter;
                dialogueTextMesh.SetText(typedText);
                yield return new WaitForSeconds(durationByLetter);
            }
        }
    }
}