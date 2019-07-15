using System;
using UnityEngine;

namespace Dialogues.Events {
    [Serializable]
    public class FriendAnimatorModificationEvent : DialogueEvent {
        public RuntimeAnimatorController friendAnimator;
    }
}