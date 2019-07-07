using System.Collections;
using System.Collections.Generic;
using Characters;
using UnityEngine;
using XNode;

namespace Dialogues {
    [NodeTint("#4d9599")] [CreateNodeMenu("ChatNode")]
    public class ChatNode : DialogueNode {
        public Character character;
        public ChatContent content;
        public float sentenceDurationInSeconds;
        public float totalDurationInSeconds;

        [Output(dynamicPortList = true)]
        public List<ChatNodeConditionsList> continuationConditions = new List<ChatNodeConditionsList>();

/*        [Output(dynamicPortList = true)]
        public List<ChatNodeCondition> interruptionConditions = new List<ChatNodeCondition>();*/
        // TODO: Use this second list when the following xNode issue gets solved : https://github.com/Siccity/xNode/issues/169

/*        public void PickContinuation(int index) {
            NodePort port = null;

            if (continuationConditions.Count <= index) return;
            port = GetOutputPort(nameof(continuationConditions) + " " + index);
            if (port == null) return;

            for (int i = 0; i < port.ConnectionCount; i++) {
                NodePort connection = port.GetConnection(i);
                ((DialogueNode) connection.node).Trigger();
            }
        }*/

        public void PickContinuation(int? index) {
            NodePort port = null;
            if (index == null) return;
            if (continuationConditions.Count <= index) return;
            port = GetOutputPort(nameof(continuationConditions) + " " + index);
            if (port == null) return;

            for (int i = 0; i < port.ConnectionCount; i++) {
                NodePort connection = port.GetConnection(i);
                ((DialogueNode) connection.node).Trigger();
            }
        }

/*        public void PickInterruption(int index) {
            NodePort port = null;

            port = GetOutputPort(nameof(interruptionConditions) + " " + index);
            if (port == null) return;

            for (int i = 0; i < port.ConnectionCount; i++) {
                NodePort connection = port.GetConnection(i);
                ((DialogueNode) connection.node).Trigger();
            }
        }*/


        public override void Trigger() {
            DialogueGraph dialogueGraph = ((DialogueGraph) graph);
            dialogueGraph.GameManager.ChatNodeCoroutinesManager.StopAllCoroutines();
            dialogueGraph.HandleChatNodeChange(this);
            dialogueGraph.GameManager.ChatNodeCoroutinesManager.StartCoroutine(
                ContinueConversation());
        }

/*        private IEnumerator ContinueConversation() {
            yield return new WaitForSeconds(totalDurationInSeconds);
            int continuationIndex = ((DialogueGraph) graph).GameManager.GaugesDecisionMaker.GetContinuationIndex();
            PickContinuation(continuationIndex);
        }*/

        private IEnumerator ContinueConversation() {
            yield return new WaitForSeconds(totalDurationInSeconds);
            int? continuationIndex = ((DialogueGraph) graph).GameManager.GaugesDecisionMaker.GetContinuationIndex();
            PickContinuation(continuationIndex);
        }
    }
}