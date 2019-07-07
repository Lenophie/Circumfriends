using System;

namespace Dialogues.Events {
    [Serializable]
    public class InputsEnablingEvent : DialogueEvent {
        public bool enableInputs;
    }
}