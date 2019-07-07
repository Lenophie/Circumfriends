using UnityEngine;

namespace FriendZones {
    public class Gauge {
        public float MaxHeight { get; private set; }
        public float FillHeight { get; private set; } // Between 0 and 1
        private float fillRateSpeed;

        public Gauge() {
            MaxHeight = 0f;
            FillHeight = 0f;
            fillRateSpeed = 10f;
        }

        public void IncrementFillRate() {
            FillHeight += fillRateSpeed * Time.deltaTime;
            if (FillHeight > MaxHeight) FillHeight = MaxHeight;
        }

        public void ChangeFillRateSpeed(float newFillRateSpeed) {
            fillRateSpeed = newFillRateSpeed;
        }

        public void ChangeMaxHeight(float newMaxHeight) {
            MaxHeight = newMaxHeight;
            Defill();
        }

        public void Defill() {
            FillHeight = 0f;
        }
    }
}