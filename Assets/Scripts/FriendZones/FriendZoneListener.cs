using UnityEngine;

namespace FriendZones {
    public class FriendZoneListener : MonoBehaviour {
        private FriendZone friendZone = null;

        public void SetCorrespondingFriendZone(FriendZone friendZone) {
            if (this.friendZone == null) this.friendZone = friendZone;
        }

        public void NotifyMeEnteringZone() {
            friendZone.NotifyMeEnteringZone();
        }

        public void NotifyMeExitingZone() {
            friendZone.NotifyMeExitingZone();
        }
    }
}