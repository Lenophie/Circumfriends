using System;

namespace Dialogues.Events {
    [Serializable]
    public class MeSpeedModificationEvent : DialogueEvent {
        public float rotationSpeed;
        public bool isRotationClockwise = true;
    }
}