using UnityEngine;

namespace Renders {
    public class CircleLineDrawing : MonoBehaviour {
        [SerializeField] private LineRenderer lineRenderer = default;
        private int points;
        [SerializeField] private float radius = default;

        public void Start() {
            points = 200;
            lineRenderer.positionCount = points;
            Vector3[] positions = new Vector3[points];
            for (int i = 0; i < points; i++) {
                float rad = Mathf.Deg2Rad * (i * 360f / points);
                positions[i] = new Vector3(Mathf.Sin(rad) * radius, Mathf.Cos(rad) * radius, 0f);
            }
            lineRenderer.SetPositions(positions);
        }
    }
}
