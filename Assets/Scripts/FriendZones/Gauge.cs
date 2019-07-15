using UnityEngine;

namespace FriendZones {
    /**
     * This class handles a FriendZone's gauge shape and filling
     */
    public class Gauge {
        public float MaxHeight { get; private set; } // The gauge's height (in pixels)
        public float FillHeight { get; private set; } // Between 0 and 1
        private float fillRateSpeed; // The speed at which the gauge is being filled

        public Gauge() {
            MaxHeight = 0f;
            FillHeight = 0f;
            fillRateSpeed = 10f;
        }

        // Fills the gauge
        public void IncrementFillRate() {
            FillHeight += fillRateSpeed * Time.deltaTime;
            if (FillHeight > MaxHeight) FillHeight = MaxHeight;
        }

        // Changes the gauge's fill rate speed
        public void ChangeFillRateSpeed(float newFillRateSpeed) {
            fillRateSpeed = newFillRateSpeed;
        }

        // Changes the gauge's height
        public void ChangeMaxHeight(float newMaxHeight) {
            MaxHeight = newMaxHeight;
            Defill();
        }

        // Empties the gauge
        public void Defill() {
            FillHeight = 0f;
        }
    }
}