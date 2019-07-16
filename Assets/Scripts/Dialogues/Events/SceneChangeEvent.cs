using System;

namespace Dialogues.Events {
    /**
     * This class serializes the event of a scene change
     */
    [Serializable]
    public class SceneChangeEvent : DialogueEvent {
        public string nextSceneName; // The scene to load
    }
}