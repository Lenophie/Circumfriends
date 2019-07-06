using System;

namespace Dialogues.Events {
    [Serializable]
    public class MeResistanceModificationEvent : DialogueEvent {
        public float resistance;
    }
}