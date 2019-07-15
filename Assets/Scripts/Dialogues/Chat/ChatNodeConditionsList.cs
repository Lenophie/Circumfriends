using System;
using System.Collections.Generic;

namespace Dialogues.Chat {
    [Serializable]
    /**
     * This class is used to serialize the conditions under which ChatNodes outputs are triggered
     */
    public class ChatNodeConditionsList {
        public bool isInterrupting; // TODO: Remove when issue discussed in ChatNode is solved
        public List<ChatNodeCondition> chatNodeConditions;
    }
}