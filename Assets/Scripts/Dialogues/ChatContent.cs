using System;
using UnityEngine;

namespace Dialogues {
    [Serializable]
    public class ChatContent {
        [TextArea] public string frenchText;
        [TextArea] public string englishText;
    }
}