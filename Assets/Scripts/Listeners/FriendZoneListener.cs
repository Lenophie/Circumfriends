using Constants;
using Controllers;
using UnityEngine;

namespace Listeners {
    public class FriendZoneListener : MonoBehaviour {
        [SerializeField] private FriendZones zone = default;
        [SerializeField] private MeController meController = default;

        private void OnTriggerEnter2D(Collider2D collider) {
            meController.MeFriendZonesHandler.NotifyMeEnteringZone(zone);
        }

        private void OnTriggerExit2D(Collider2D collider) {
            meController.MeFriendZonesHandler.NotifyMeExitingZone(zone);
        }
    }
}