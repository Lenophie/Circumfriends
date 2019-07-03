using System.Linq;
using Constants;
using Managers;
using UnityEngine;
using XNode;

namespace Dialogues {
    [CreateAssetMenu(menuName = "Dialogue/Graph")]
    public class DialogueGraph : NodeGraph {
        [HideInInspector] public ChatNode currentChatNode;
        private GameManager gameManager;

        public void Restart(GameManager gameManager) {
            //Find the first DialogueNode without any inputs. This is the starting node.
            currentChatNode = nodes.Find(x => x is ChatNode && x.Inputs.All(y => !y.IsConnected)) as ChatNode;
            this.gameManager = gameManager;
        }

        public void PickAnswerToCurrentChatNode(int index) {
            if (currentChatNode) currentChatNode.PickAnswer(index);
        }

        public void HandleEvent(DialogueEventsEnum dialogueEventsEnum, DialogueEvent dialogueEvent) {
            gameManager.HandleDialogueEvent(dialogueEventsEnum, dialogueEvent);
        }
    }
}