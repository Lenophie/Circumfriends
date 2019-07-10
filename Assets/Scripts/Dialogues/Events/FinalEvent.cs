using System;

namespace Dialogues.Events {
    [Serializable]
    public class FinalEvent : DialogueEvent {
        public string nextSceneName;
    }
}