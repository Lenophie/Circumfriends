using Inputs;
using UnityEngine;

namespace Controllers {
    public class MeController : MonoBehaviour {
        [SerializeField] private Rigidbody2D friendRigidbody = default;
        [SerializeField] private Rigidbody2D meRigidbody = default;
        private MeRotationController meRotationController;
        private MeResistanceController meResistanceController;
        public MeFriendZonesHandler MeFriendZonesHandler { get; private set; }
        private PlayerInputs playerInputs;

        private void Start() {
            meRotationController = new MeRotationController(friendRigidbody, meRigidbody);
            meResistanceController = new MeResistanceController(friendRigidbody, meRigidbody);
            MeFriendZonesHandler = new MeFriendZonesHandler();
        }

        private void Update() {
            meRotationController.UpdateRotation();
            meResistanceController.UpdateResistance(playerInputs.Resist);
            MeFriendZonesHandler.DetermineCurrentFriendZone();
        }

        public void SetPlayerInputs(PlayerInputs playerInputs) {
            this.playerInputs = playerInputs;
        }
    }
}