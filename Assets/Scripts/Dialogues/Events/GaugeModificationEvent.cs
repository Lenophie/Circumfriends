using System;
using Constants;

namespace Dialogues.Events {
    [Serializable]
    public class GaugeModificationEvent : DialogueEvent {
        public FriendZonesEnum friendZonesEnum;
        public float maxHeight = 300f;
        public float fillRateSpeed = 10f;
    }
}