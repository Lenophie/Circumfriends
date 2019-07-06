using UnityEngine;

namespace FriendZones {
    public class MeFriendZonesCollisionsListener : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider) {
            FriendZoneListener friendZoneListener = collider.GetComponent<FriendZoneListener>();
            if (friendZoneListener) friendZoneListener.NotifyMeEnteringZone();
        }

        private void OnTriggerExit(Collider collider) {
            FriendZoneListener friendZoneListener = collider.GetComponent<FriendZoneListener>();
            if (friendZoneListener) friendZoneListener.NotifyMeExitingZone();
        }
    }
}
