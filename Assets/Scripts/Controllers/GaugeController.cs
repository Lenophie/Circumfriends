using UnityEngine;

namespace Controllers {
    [ExecuteAlways]
    public class GaugeController : MonoBehaviour {
        [SerializeField] private RectTransform gaugeTransform;
        [SerializeField] private RectTransform gaugeFillTransform;
        [Range(0, 1)] public float gaugeFill;

        private void Update() {
            gaugeFillTransform.sizeDelta = new Vector2(gaugeFillTransform.sizeDelta.x, -gaugeTransform.rect.height * gaugeFill);
        }
    }
}
