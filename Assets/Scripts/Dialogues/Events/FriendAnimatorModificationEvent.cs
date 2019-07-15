using System;
using UnityEngine;

namespace Dialogues.Events {
    /**
     * This class serializes a modification of the Friend's animator
     */
    [Serializable]
    public class FriendAnimatorModificationEvent : DialogueEvent {
        public RuntimeAnimatorController friendAnimator; // The new animator to use on the Friend
    }
}