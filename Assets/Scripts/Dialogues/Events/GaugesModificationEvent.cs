using System;
using System.Collections.Generic;

namespace Dialogues.Events {
    /**
     * This class serializes a list of gauge modifications
     */
    [Serializable]
    public class GaugesModificationEvent : DialogueEvent {
        public List<GaugeModificationEvent> gaugeModificationEvents;
    }
}