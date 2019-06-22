using Inputs;
using UnityEngine;

namespace Controllers {
    public class MeController : MonoBehaviour {
        [SerializeField] private Rigidbody2D friendRigidbody = default;
        [SerializeField] private Rigidbody2D meRigidbody = default;
        private MeRotationController meRotationController;
        private PlayerInputs playerInputs;

        private void Start() {
            meRotationController = new MeRotationController(friendRigidbody, meRigidbody);
        }

        private void Update() {
            meRotationController.UpdateRotation();
        }

        public void SetPlayerInputs(PlayerInputs playerInputs) {
            this.playerInputs = playerInputs;
            Debug.Log(this.playerInputs.Resist);
        }
    }
}