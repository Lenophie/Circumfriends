using FriendZones;
using UnityEngine;

namespace Controllers {
    public class GaugeUIController : MonoBehaviour {
        private Gauge gauge;
        [SerializeField] private RectTransform gaugeTransform = default;
        [SerializeField] private RectTransform gaugeFillTransform = default;

        public void SetGauge(Gauge gauge) {
            this.gauge = gauge;
        }

        private void LateUpdate() {
            gaugeFillTransform.sizeDelta = new Vector2(gaugeFillTransform.sizeDelta.x, gauge.FillHeight);
            gaugeTransform.sizeDelta = new Vector2(gaugeTransform.sizeDelta.x, gauge.MaxHeight);
        }
    }
}
