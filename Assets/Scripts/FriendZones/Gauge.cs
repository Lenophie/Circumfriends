using UnityEngine;

namespace FriendZones {
    public class Gauge {
        public float Size { get; private set; }
        public float FillRate { get; private set; } // Between 0 and 1
        private readonly float fillRateSpeed;

        public Gauge() {
            Size = 0f;
            FillRate = 0f;
            fillRateSpeed = 1f;
        }

        public void IncrementFillRate() {
            FillRate += fillRateSpeed * Time.deltaTime;
            if (FillRate > 1f) FillRate = 1f;
        }

        public void ChangeSize(float size) {
            Size = size;
            FillRate = 0f;
        }
    }
}