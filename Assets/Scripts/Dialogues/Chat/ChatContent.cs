using System;
using UnityEngine;

namespace Dialogues.Chat {
    /**
     * This class is used to serialize the content of a ChatNode
     */
    [Serializable]
    public class ChatContent {
        [TextArea] public string frenchText; // The french version of the dialogue line
        [TextArea] public string englishText; // The english version of the dialogue line
    }
}