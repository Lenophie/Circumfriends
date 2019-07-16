using Dialogues.Events;
using Inputs;
using UnityEngine;

namespace Controllers {
    public class MeController : MonoBehaviour {
        [SerializeField] private Rigidbody friendRigidbody = default;
        [SerializeField] private Rigidbody meRigidbody = default;
        private MeRotationController meRotationController;
        private MeResistanceController meResistanceController;
        private PlayerInputs playerInputs;

        private void Start() {
            meRotationController = new MeRotationController(friendRigidbody, meRigidbody);
            meResistanceController = new MeResistanceController(friendRigidbody, meRigidbody);
            UpdateRigidbodyVelocity();
        }

        private void Update() {
            meResistanceController.UpdateResistance(playerInputs.Resist);
        }

        private void FixedUpdate() {
            UpdateRigidbodyVelocity();
        }

        public void SetPlayerInputs(PlayerInputs playerInputs) {
            this.playerInputs = playerInputs;
        }

        public void HandleMeResistanceModificationEvent(
            MeResistanceModificationEvent meResistanceModificationEvent) {
            meResistanceController.SetResistanceModifier(meResistanceModificationEvent.resistance);
        }

        public void HandleMeSpeedModificationEvent(
            MeSpeedModificationEvent meSpeedModificationEvent) {
            meRotationController.SetSpeedModifier(meSpeedModificationEvent.rotationSpeed,
                meSpeedModificationEvent.isRotationClockwise);
        }

        private void UpdateRigidbodyVelocity() {
            Vector2 tangentVelocity = meRotationController.GetTargetTangentialVelocity(); // Force the tangential velocity to match the speed set by the current dialogue
            Vector2 normalVelocity = meResistanceController.GetCurrentNormalVelocity(); // Don't meddle with attraction/resistance physics

            meRigidbody.velocity = tangentVelocity + normalVelocity;
        }
    }
}