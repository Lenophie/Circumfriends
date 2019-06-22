using Constants;
using UnityEngine;

namespace Controllers {
    public class MeFriendZonesHandler {
        public FriendZones? CurrentFriendZone { get; private set; }
        private bool isMeInNoGoZone;
        private bool isMeInDiscomfortZone;
        private bool isMeInComfortZone;
        private bool isMeInDistantZone;

        public MeFriendZonesHandler() {
            CurrentFriendZone = null;
            isMeInNoGoZone = false;
            isMeInDiscomfortZone = false;
            isMeInComfortZone = false;
            isMeInDistantZone = false;
        }

        public void NotifyMeEnteringZone(FriendZones zone) {
            switch (zone) {
                case FriendZones.NoGo:
                    isMeInNoGoZone = true;
                    isMeInDiscomfortZone = true;
                    isMeInComfortZone = true;
                    isMeInDistantZone = true;
                    break;
                case FriendZones.Discomfort:
                    isMeInDiscomfortZone = true;
                    isMeInComfortZone = true;
                    isMeInDistantZone = true;
                    break;
                case FriendZones.Comfort:
                    isMeInComfortZone = true;
                    isMeInDistantZone = true;
                    break;
                case FriendZones.Distant:
                    isMeInDistantZone = true;
                    break;
                default:
                    Debug.LogError("A FriendZoneListener sent an invalid friendZone to MeFriendZonesHandler");
                    break;
            }
        }

        public void NotifyMeExitingZone(FriendZones zone) {
            switch (zone) {
                case FriendZones.NoGo:
                    isMeInNoGoZone = false;
                    break;
                case FriendZones.Discomfort:
                    isMeInNoGoZone = false;
                    isMeInDiscomfortZone = false;
                    break;
                case FriendZones.Comfort:
                    isMeInNoGoZone = false;
                    isMeInDiscomfortZone = false;
                    isMeInComfortZone = false;
                    break;
                case FriendZones.Distant:
                    isMeInNoGoZone = false;
                    isMeInDiscomfortZone = false;
                    isMeInComfortZone = false;
                    isMeInDistantZone = false;
                    break;
                default:
                    Debug.LogError("A FriendZoneListener sent an invalid friendZone to MeFriendZonesHandler");
                    break;
            }
        }

        public void DetermineCurrentFriendZone() {
            if (isMeInNoGoZone) CurrentFriendZone = FriendZones.NoGo;
            else if (isMeInDiscomfortZone) CurrentFriendZone = FriendZones.Discomfort;
            else if (isMeInComfortZone) CurrentFriendZone = FriendZones.Comfort;
            else if (isMeInDistantZone) CurrentFriendZone = FriendZones.Distant;
            else CurrentFriendZone = null;
        }
    }
}