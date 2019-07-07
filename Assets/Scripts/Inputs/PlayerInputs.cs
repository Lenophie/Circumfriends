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

        private PlayerInputs(float resist) {
            Resist = resist;
        }

        public static PlayerInputs GetDisabledInputs() {
            return new PlayerInputs(0f);
        }
    }
}