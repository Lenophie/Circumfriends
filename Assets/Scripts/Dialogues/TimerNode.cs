using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogues {
    [CreateNodeMenu("TimerNode")]
    public class TimerNode : DialogueNode {
        [Output(dynamicPortList = true)] public List<float> delays;

        public override void Trigger() {
            for (int i = 0; i < delays.Count; i++)
                ((DialogueGraph) graph).GameManager.StartCoroutine(TriggerOutputWithDelay(i));
        }

        private IEnumerator TriggerOutputWithDelay(int index) {
            NodePort port = GetOutputPort("delays " + index);
            yield return new WaitForSeconds(delays[index]);
            for (int j = 0; j < port.ConnectionCount; j++) {
                NodePort connection = port.GetConnection(j);
                ((DialogueNode) connection.node).Trigger();
            }
        }
    }
}