using UnityEngine;

namespace Controllers {
    [ExecuteAlways]
    public class GaugeUIController : MonoBehaviour {
        [SerializeField] private RectTransform gaugeTransform = default;
        [SerializeField] private RectTransform gaugeFillTransform = default;
        [Range(0, 1)] public float gaugeFill = default;

        private void Update() {
            gaugeFillTransform.sizeDelta =
                new Vector2(gaugeFillTransform.sizeDelta.x, gaugeTransform.rect.height * gaugeFill);
        }

        public void SetGaugeHeight(float newHeight) {
            gaugeTransform.sizeDelta = new Vector2(gaugeTransform.sizeDelta.x, newHeight);
        }
    }
}
