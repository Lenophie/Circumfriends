using System.Collections;
using Constants;
using Dialogues.Chat;
using TMPro;
using UnityEngine;

namespace Managers {
    /**
     * This class handles dialogues : It extracts the content from ChatNodes and type them in the Dialogue Banner.
     */
    public class DialogueManager {
        private ChatNode currentChatNode;
        private readonly ChatNodeCoroutinesManager chatNodeCoroutinesManager;
        private readonly LanguagesEnum language;
        private readonly TextMeshProUGUI dialogueTextMesh;
        private readonly TextMeshProUGUI dialogueTimerTextMesh;
        private readonly Animator dialogueHeadshotAnimator;

        public DialogueManager(TextMeshProUGUI dialogueTextMesh, TextMeshProUGUI dialogueTimerTextMesh,
            Animator dialogueHeadshotAnimator, LanguagesEnum language,
            ChatNodeCoroutinesManager chatNodeCoroutinesManager) {
            this.dialogueTextMesh = dialogueTextMesh;
            this.dialogueTimerTextMesh = dialogueTimerTextMesh;
            this.dialogueHeadshotAnimator = dialogueHeadshotAnimator;
            this.language = language;
            this.chatNodeCoroutinesManager = chatNodeCoroutinesManager;
        }

        /**
         * Sets the current ChatNode to another one, meaning a new dialogue line has to be displayed
         */
        public void ChangeCurrentChatNode(ChatNode newChatNode) {
            // Change the stored current ChatNode
            currentChatNode = newChatNode;

            // Start the text-typing coroutine
            string currentChatNodeContent = GetCurrentChatNodeContent();
            chatNodeCoroutinesManager.StartCoroutine(TypeText(currentChatNodeContent, currentChatNode.sentenceDurationInSeconds,
                currentChatNode.totalDurationInSeconds));

            // Change the dialogue headshot
            dialogueHeadshotAnimator.runtimeAnimatorController = currentChatNode.character.animatorController;
        }

        /**
         * Extracts the content from the ChatNode based on the user language
         */
        private string GetCurrentChatNodeContent() {
            return language == LanguagesEnum.English ? currentChatNode.content.englishText :
                language == LanguagesEnum.French ? currentChatNode.content.frenchText : "";
        }

        /**
         * This coroutines is used to delay the typing of each letter of a dialogue line
         */
        private IEnumerator TypeText(string text, float totalSentenceDuration, float totalDuration) {
            // Initialisation
            string typedText = "";
            float durationByLetter = totalSentenceDuration / text.Length;
            dialogueTextMesh.SetText(typedText);
            dialogueTimerTextMesh.SetText("");

            // Type the text
            foreach (char letter in text.ToCharArray()) {
                // Add the next letter to the displayed text
                typedText += letter;
                dialogueTextMesh.SetText(typedText);

                // Wait before the next one
                yield return new WaitForSeconds(durationByLetter);
            }

            // Now that the text is fully typed, update the dialogue countdown
            float countdown = totalDuration - totalSentenceDuration;
            while (countdown >= 1f) {
                dialogueTimerTextMesh.SetText(((int) countdown).ToString());
                countdown -= 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}