using UnityEngine;

namespace FriendZones {
    public class Gauge {
        public float MaxHeight { get; private set; }
        public float FillHeight { get; private set; } // Between 0 and 1
        private readonly float fillRateSpeed;

        public Gauge() {
            MaxHeight = 0f;
            FillHeight = 0f;
            fillRateSpeed = 10f;
        }

        public void IncrementFillRate() {
            FillHeight += fillRateSpeed * Time.deltaTime;
            if (FillHeight > MaxHeight) FillHeight = MaxHeight;
        }

        public void ChangeMaxHeight(float newMaxHeight) {
            MaxHeight = newMaxHeight;
            FillHeight = 0f;
        }
    }
}