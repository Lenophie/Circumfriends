using System;

namespace Dialogues.Events {
    [Serializable]
    public class FriendAttractionModificationEvent : DialogueEvent {
        public float attraction;
    }
}