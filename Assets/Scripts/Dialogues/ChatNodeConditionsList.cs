using System;
using System.Collections.Generic;

namespace Dialogues {
    [Serializable]
    public class ChatNodeConditionsList {
        public bool isInterrupting; // TODO: Remove when issue discussed in ChatNode is solved
        public List<ChatNodeCondition> chatNodeConditions;
    }
}