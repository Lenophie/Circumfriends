using System;
using System.Collections.Generic;

namespace Dialogues.Events {
    [Serializable]
    public class GaugesModificationEvent : DialogueEvent {
        public List<GaugeModificationEvent> gaugeModificationEvents;
    }
}