using FriendZones;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers {
    public class GaugeUIController : MonoBehaviour {
        private Gauge gauge;
        [SerializeField] private RectTransform gaugeTransform = default;
        [SerializeField] private RectTransform gaugeFillTransform = default;
        [SerializeField] private Image gaugeFillImage = default;

        public void SetGauge(Gauge gauge, Color gaugeFillColor) {
            this.gauge = gauge;
            gaugeFillImage.color = gaugeFillColor;
        }

        private void LateUpdate() {
            if (gauge != null) {
                gaugeFillTransform.sizeDelta = new Vector2(gaugeFillTransform.sizeDelta.x, gauge.FillHeight);
                gaugeTransform.sizeDelta = new Vector2(gaugeTransform.sizeDelta.x, gauge.MaxHeight);
            }
        }
    }
}
