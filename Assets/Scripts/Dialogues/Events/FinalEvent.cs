using System;

namespace Dialogues.Events {
    /**
     * This class serializes the final event of a dialogue graph
     */
    [Serializable]
    public class FinalEvent : DialogueEvent {
        public string nextSceneName; // The scene to load
    }
}