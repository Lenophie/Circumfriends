using UnityEngine;

namespace Constants {
    public static class FriendZonesConstants {
        public static int NumberOfOuterVerticesPerFriendzone { get; private set; }
        public static float MaxLineNoiseAmplitude { get; private set; }

        public static Color NoGoZoneOut { get; private set; }
        public static Color NoGoZoneIn { get; private set; }
        public static Color DiscomfortZoneOut { get; private set; }
        public static Color DiscomfortZoneIn { get; private set; }
        public static Color ComfortZoneOut { get; private set; }
        public static Color ComfortZoneIn { get; private set; }
        public static Color DistantZoneOut { get; private set; }
        public static Color DistantZoneIn { get; private set; }

        public static void SetConstants(FriendZonesConstantsCollector friendZonesConstantsCollector) {
            NumberOfOuterVerticesPerFriendzone = friendZonesConstantsCollector.numberOfOuterVerticesPerFriendzone;
            MaxLineNoiseAmplitude = friendZonesConstantsCollector.maxLineNoiseAmplitude;
            NoGoZoneOut = friendZonesConstantsCollector.noGoZoneOut;
            NoGoZoneIn = friendZonesConstantsCollector.noGoZoneIn;
            DiscomfortZoneOut = friendZonesConstantsCollector.discomfortZoneOut;
            DiscomfortZoneIn = friendZonesConstantsCollector.discomfortZoneIn;
            ComfortZoneOut = friendZonesConstantsCollector.comfortZoneOut;
            ComfortZoneIn = friendZonesConstantsCollector.comfortZoneIn;
            DistantZoneOut = friendZonesConstantsCollector.distantZoneOut;
            DistantZoneIn = friendZonesConstantsCollector.distantZoneIn;
        }
    }
}