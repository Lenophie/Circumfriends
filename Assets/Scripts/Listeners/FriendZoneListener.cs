using Constants;
using Controllers;
using UnityEngine;

namespace Listeners {
    public class FriendZoneListener : MonoBehaviour {
        [SerializeField] private FriendZonesEnum zoneEnum = default;
        [SerializeField] private MeController meController = default;

        private void OnTriggerEnter2D(Collider2D collider) {
            meController.MeFriendZonesHandler.NotifyMeEnteringZone(zoneEnum);
        }

        private void OnTriggerExit2D(Collider2D collider) {
            meController.MeFriendZonesHandler.NotifyMeExitingZone(zoneEnum);
        }
    }
}