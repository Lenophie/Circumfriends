using System;
using Constants;

namespace Dialogues {
    [Serializable]
    public class ChatNodeCondition {
        public FriendZonesEnum friendZonesEnum;
        public ComparisonEnum comparisonEnum;
        public float gaugeHeight;
    }
}