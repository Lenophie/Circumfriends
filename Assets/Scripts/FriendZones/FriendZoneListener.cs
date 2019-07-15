using UnityEngine;

namespace FriendZones {
    /**
     * This class is used to allow communication between the player's collisions listener and FriendZones' API
     */
    public class FriendZoneListener : MonoBehaviour {
        private FriendZone friendZone = null;

        /**
         * Used to set the reference to the listener's corresponding FriendZone
         */
        public void SetCorrespondingFriendZone(FriendZone friendZone) {
            if (this.friendZone == null) this.friendZone = friendZone;
        }

        /**
         * Used to notify the FriendZone the player is in it
         * Called by the player's collisions listener
         */
        public void NotifyMeInZone() {
            friendZone.NotifyMeInZone();
        }

        /**
         * Used to notify the FriendZone the player exits it
         * Called by the player's collisions listener
         */
        public void NotifyMeExitingZone() {
            friendZone.NotifyMeExitingZone();
        }
    }
}