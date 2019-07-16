using System;

namespace Dialogues.Events {
    /**
     * This class serializes the event of a dialogue change
     */
    [Serializable]
    public class DialogueChangeEvent : DialogueEvent {
        public DialogueGraph nextDialogue; // The dialogue to load
    }
}