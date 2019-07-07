using System;
using Constants;

namespace Dialogues.Events {
    [Serializable]
    public class GaugeModificationEvent : DialogueEvent {
        public FriendZonesEnum friendZonesEnum;
        public float size = 300f;
    }
}