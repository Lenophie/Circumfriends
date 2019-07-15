using System;
using Constants;

namespace Dialogues.Events {
    /**
     * This class serializes a FriendZone's blink event
     */
    [Serializable]
    public class BlinkEvent : DialogueEvent {
        public FriendZonesEnum friendZonesEnum; // The FriendZone to blink
    }
}