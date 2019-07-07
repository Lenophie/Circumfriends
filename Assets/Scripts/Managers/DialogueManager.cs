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
        private readonly TextMeshProUGUI dialogueTimerTextMesh;
        private readonly Animator dialogueHeadshotAnimator;

        public DialogueManager(TextMeshProUGUI dialogueTextMesh, TextMeshProUGUI dialogueTimerTextMesh,
            Animator dialogueHeadshotAnimator, LanguagesEnum language, GameManager gameManager) {
            this.dialogueTextMesh = dialogueTextMesh;
            this.dialogueTimerTextMesh = dialogueTimerTextMesh;
            this.dialogueHeadshotAnimator = dialogueHeadshotAnimator;
            this.language = language;
            this.gameManager = gameManager;
        }

        public void ChangeCurrentChatNode(ChatNode newChatNode) {
            currentChatNode = newChatNode;
            string currentChatNodeContent = GetCurrentChatNodeContent();
            gameManager.StopAllCoroutines();
            gameManager.StartCoroutine(TypeText(currentChatNodeContent, currentChatNode.sentenceDurationInSeconds,
                currentChatNode.totalDurationInSeconds));
            dialogueHeadshotAnimator.runtimeAnimatorController = currentChatNode.character.animatorController;
        }

        private string GetCurrentChatNodeContent() {
            return language == LanguagesEnum.English ? currentChatNode.content.englishText :
                language == LanguagesEnum.French ? currentChatNode.content.frenchText : "";
        }

        private IEnumerator TypeText(string text, float totalSentenceDuration, float totalDuration) {
            string typedText = "";
            float durationByLetter = totalSentenceDuration / text.Length;
            dialogueTextMesh.SetText(typedText);
            dialogueTimerTextMesh.SetText("");
            foreach (char letter in text.ToCharArray()) {
                typedText += letter;
                dialogueTextMesh.SetText(typedText);
                yield return new WaitForSeconds(durationByLetter);
            }

            float countdown = totalDuration - totalSentenceDuration;
            while (countdown >= 1f) {
                dialogueTimerTextMesh.SetText(((int) countdown).ToString());
                countdown -= 1f;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}