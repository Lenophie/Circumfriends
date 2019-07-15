using UnityEngine;

namespace FriendZones {
    /*
     * This class is used to handle player's collisions with FriendZones
     */
    public class MeFriendZonesCollisionsListener : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider) {
            FriendZoneListener friendZoneListener = collider.GetComponent<FriendZoneListener>();
            if (friendZoneListener) friendZoneListener.NotifyMeInZone();
        }

        private void OnTriggerExit(Collider collider) {
            FriendZoneListener friendZoneListener = collider.GetComponent<FriendZoneListener>();
            if (friendZoneListener) friendZoneListener.NotifyMeExitingZone();
        }

        private void OnTriggerStay(Collider collider) {
            FriendZoneListener friendZoneListener = collider.GetComponent<FriendZoneListener>();
            if (friendZoneListener) friendZoneListener.NotifyMeInZone();
        }
    }
}
