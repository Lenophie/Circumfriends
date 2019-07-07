using System.Linq;
using Constants;
using Dialogues.Events;
using Managers;
using UnityEngine;
using XNode;

namespace Dialogues {
    [CreateAssetMenu(menuName = "Dialogue/Graph")]
    public class DialogueGraph : NodeGraph {
        [HideInInspector] public ChatNode currentChatNode;
        public GameManager GameManager { get; private set; } // Getter is public in order to start coroutines
        private DialogueManager dialogueManager;

        public void Restart(GameManager gameManager, DialogueManager dialogueManager) {
            GameManager = gameManager;
            this.dialogueManager = dialogueManager;
            InitialNode initialNode =
                nodes.Find(x => x is InitialNode && x.Inputs.All(y => !y.IsConnected)) as InitialNode;
            if (initialNode == null) Debug.LogError("Graph has no initial node");
            else initialNode.Trigger();
        }

        public void PickAnswerToCurrentChatNode(int index) {
            if (currentChatNode) currentChatNode.PickAnswer(index);
        }

        public void HandleEvent(DialogueEventsEnum dialogueEventsEnum, DialogueEvent dialogueEvent) {
            GameManager.HandleDialogueEvent(dialogueEventsEnum, dialogueEvent);
        }

        public void HandleChatNodeChange(ChatNode newChatNode) {
            currentChatNode = newChatNode;
            dialogueManager.ChangeCurrentChatNode(currentChatNode);
        }
    }
}