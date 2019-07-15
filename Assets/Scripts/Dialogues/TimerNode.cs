using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogues {
    /**
     * This Node is used to delay the trigger of the input Node
     */
    [CreateNodeMenu("TimerNode")]
    public class TimerNode : DialogueNode {
        [Output(dynamicPortList = true)] public List<float> delays; // The delays to apply before calling the Trigger of the respective output nodes

        /**
         * This method starts the coroutines that will call the output triggers
         */
        public override void Trigger() {
            for (int i = 0; i < delays.Count; i++)
                ((DialogueGraph) graph).GameManager.StartCoroutine(TriggerOutputWithDelay(i));
        }

        /**
         * The coroutine that triggers an output with a delay
         */
        private IEnumerator TriggerOutputWithDelay(int index) {
            // Retrieve the corresponding output NodePort
            NodePort port = GetOutputPort("delays " + index);

            // Wait for the value for the value of the delay in seconds
            yield return new WaitForSeconds(delays[index]);

            // Trigger each Node connected to the NodePort
            for (int j = 0; j < port.ConnectionCount; j++) {
                NodePort connection = port.GetConnection(j);
                ((DialogueNode) connection.node).Trigger();
            }
        }
    }
}