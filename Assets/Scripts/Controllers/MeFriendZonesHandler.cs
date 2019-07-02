using Constants;
using UnityEngine;

namespace Controllers {
    public class MeFriendZonesHandler {
        public FriendZonesEnum? CurrentFriendZoneEnum { get; private set; }
        private bool isMeInNoGoZone;
        private bool isMeInDiscomfortZone;
        private bool isMeInComfortZone;
        private bool isMeInDistantZone;

        public MeFriendZonesHandler() {
            CurrentFriendZoneEnum = null;
            isMeInNoGoZone = false;
            isMeInDiscomfortZone = false;
            isMeInComfortZone = false;
            isMeInDistantZone = false;
        }

        public void NotifyMeEnteringZone(FriendZonesEnum zoneEnum) {
            switch (zoneEnum) {
                case FriendZonesEnum.NoGo:
                    isMeInNoGoZone = true;
                    isMeInDiscomfortZone = true;
                    isMeInComfortZone = true;
                    isMeInDistantZone = true;
                    break;
                case FriendZonesEnum.Discomfort:
                    isMeInDiscomfortZone = true;
                    isMeInComfortZone = true;
                    isMeInDistantZone = true;
                    break;
                case FriendZonesEnum.Comfort:
                    isMeInComfortZone = true;
                    isMeInDistantZone = true;
                    break;
                case FriendZonesEnum.Distant:
                    isMeInDistantZone = true;
                    break;
                default:
                    Debug.LogError("A FriendZoneListener sent an invalid friendZone to MeFriendZonesHandler");
                    break;
            }
        }

        public void NotifyMeExitingZone(FriendZonesEnum zoneEnum) {
            switch (zoneEnum) {
                case FriendZonesEnum.NoGo:
                    isMeInNoGoZone = false;
                    break;
                case FriendZonesEnum.Discomfort:
                    isMeInNoGoZone = false;
                    isMeInDiscomfortZone = false;
                    break;
                case FriendZonesEnum.Comfort:
                    isMeInNoGoZone = false;
                    isMeInDiscomfortZone = false;
                    isMeInComfortZone = false;
                    break;
                case FriendZonesEnum.Distant:
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
            if (isMeInNoGoZone) CurrentFriendZoneEnum = FriendZonesEnum.NoGo;
            else if (isMeInDiscomfortZone) CurrentFriendZoneEnum = FriendZonesEnum.Discomfort;
            else if (isMeInComfortZone) CurrentFriendZoneEnum = FriendZonesEnum.Comfort;
            else if (isMeInDistantZone) CurrentFriendZoneEnum = FriendZonesEnum.Distant;
            else CurrentFriendZoneEnum = null;
        }
    }
}