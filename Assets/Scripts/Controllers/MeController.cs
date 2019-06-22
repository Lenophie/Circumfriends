using UnityEngine;

namespace Controllers {
    public class MeController : MonoBehaviour {
        [SerializeField] private Rigidbody2D friendRigidbody = default;
        [SerializeField] private Rigidbody2D meRigidbody = default;
        private MeRotationController meRotationController;

        private void Start() {
            meRotationController = new MeRotationController(friendRigidbody, meRigidbody);
        }

        private void Update() {
            meRotationController.UpdateRotation();
        }
    }
}