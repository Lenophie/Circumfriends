using System;
using Constants;

namespace Dialogues.Chat {
    /**
     * This class is used to serialize the condition under which a ChatNode output is triggered
     * * It reads as follows : A given FriendZone's gauge must be superior/lower to a given value
     */
    [Serializable]
    public class ChatNodeCondition {
        public FriendZonesEnum friendZonesEnum;
        public ComparisonEnum comparisonEnum;
        public float gaugeHeight;
    }
}