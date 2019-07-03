using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace Dialogues {
    public class TimerNode : DialogueNode {
        public float delay;
        [Output(dynamicPortList = true, backingValue = ShowBackingValue.Never)] public List<float> outputs;

        public override void Trigger() {
            ((DialogueGraph) graph).GameManager.StartCoroutine(TriggerOutputs());
        }

        private IEnumerator TriggerOutputs() {
            yield return new WaitForSeconds(delay);
            for (int i = 0; i < outputs.Count; i++) {
                NodePort port = GetOutputPort("outputs " + i);
                for (int j = 0; j < port.ConnectionCount; j++) {
                    NodePort connection = port.GetConnection(j);
                    ((DialogueNode) connection.node).Trigger();
                }
            }
        }
    }
}