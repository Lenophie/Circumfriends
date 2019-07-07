using System;
using Constants;

namespace Dialogues.Events {
    [Serializable]
    public class BlinkEvent : DialogueEvent {
        public FriendZonesEnum friendZonesEnum;
    }
}