using UnityEngine;

namespace Inputs {
    /**
     * This class collects the raw inputs
     */
    public class PlayerInputs {
        public readonly float Resist;

        public PlayerInputs() {
            Resist = Input.GetAxisRaw("Resist");
        }
    }
}