using System.Collections;
using System.Collections.Generic;
using Characters;
using UnityEngine;
using XNode;

namespace Dialogues.Chat {
    /**
     * This node is used to hold a dialogue line, its respective character and the branching conditions
     */
    [NodeTint("#4d9599")] [CreateNodeMenu("ChatNode")]
    public class ChatNode : DialogueNode {
        public Character character; // The character speaking
        public ChatContent content; // The dialogue line
        public float sentenceDurationInSeconds; // The time the sentence takes to be fully displayed on screen
        public float totalDurationInSeconds; // The time before the Nodes connected to the conditions are triggered
        // sentenceDurationInSeconds - totalDurationInSeconds is the time during which the full sentence is displayed before moving on the next

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

        /**
         * The coroutine used to trigger the outputs after a delay
         */
        private IEnumerator ContinueConversation() {
            yield return new WaitForSeconds(totalDurationInSeconds);
            int? continuationIndex = ((DialogueGraph) graph).GameManager.GaugesDecisionMaker.GetContinuationIndex();
            PickContinuation(continuationIndex);
        }
    }
}