using System;

namespace Dialogues.Events {
    /**
     * This class serializes a change in rotational speed of the player
     */
    [Serializable]
    public class MeSpeedModificationEvent : DialogueEvent {
        public float rotationSpeed; // The desired rotation speed
        public bool isRotationClockwise = true; // If true, the rotation is clockwise. If false, it is counter-clockwise
    }
}