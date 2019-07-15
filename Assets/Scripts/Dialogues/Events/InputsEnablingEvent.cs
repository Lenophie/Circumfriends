using System;

namespace Dialogues.Events {
    /**
     * This class serializes an inputs enabling event
     */
    [Serializable]
    public class InputsEnablingEvent : DialogueEvent {
        public bool enableInputs; // If true, inputs will be enabled. If false, inputs will be disabled.
    }
}