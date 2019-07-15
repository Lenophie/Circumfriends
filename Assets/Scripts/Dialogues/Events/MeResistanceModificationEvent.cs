using System;

namespace Dialogues.Events {
    /**
     * This class serializes a change in the resistance of the player to the attraction of the Friend
     */
    [Serializable]
    public class MeResistanceModificationEvent : DialogueEvent {
        public float resistance; // The strength of the resistance
    }
}