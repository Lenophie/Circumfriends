using System;

namespace Dialogues.Events {
    /**
     * This class serializes a change in the Friend's attraction strength
     */
    [Serializable]
    public class FriendAttractionModificationEvent : DialogueEvent {
        public float attraction; // The strength of the attraction pull
    }
}