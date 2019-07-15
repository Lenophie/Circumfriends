using System;
using Constants;

namespace Dialogues.Events {
    /**
     * This class serializes a change in height or fill rate for a given gauge
     */
    [Serializable]
    public class GaugeModificationEvent : DialogueEvent {
        public FriendZonesEnum friendZonesEnum; // The FriendZone whose gauge will be modified
        public float maxHeight = 300f; // The new height in pixels of the gauge
        public float fillRateSpeed = 10f; // The new fill rate speed of the gauge
    }
}