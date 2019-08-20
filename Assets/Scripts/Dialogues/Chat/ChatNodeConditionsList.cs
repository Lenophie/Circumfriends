using System;
using System.Collections.Generic;

namespace Dialogues.Chat {
    [Serializable]
    /**
     * This class is used to serialize the conditions under which ChatNodes outputs are triggered
     */
    public class ChatNodeConditionsList {
        public List<ChatNodeCondition> chatNodeConditions;
    }
}