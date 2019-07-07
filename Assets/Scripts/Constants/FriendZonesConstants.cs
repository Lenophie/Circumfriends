using UnityEngine;

namespace Constants {
    public static class FriendZonesConstants {
        public static int NumberOfOuterVerticesPerFriendzone { get; private set; }
        public static float MaxLineNoiseAmplitude { get; private set; }

        public static Color NoGoZoneOutColor { get; private set; }
        public static Color NoGoZoneInColor { get; private set; }
        public static Color DiscomfortZoneOutColor { get; private set; }
        public static Color DiscomfortZoneInColor { get; private set; }
        public static Color ComfortZoneOutColor { get; private set; }
        public static Color ComfortZoneInColor { get; private set; }
        public static Color DistantZoneOutColor { get; private set; }
        public static Color DistantZoneInColor { get; private set; }

        public static void SetConstants(FriendZonesConstantsCollector friendZonesConstantsCollector) {
            NumberOfOuterVerticesPerFriendzone = friendZonesConstantsCollector.numberOfOuterVerticesPerFriendzone;
            MaxLineNoiseAmplitude = friendZonesConstantsCollector.maxLineNoiseAmplitude;
            NoGoZoneOutColor = friendZonesConstantsCollector.noGoZoneOutColor;
            NoGoZoneInColor = friendZonesConstantsCollector.noGoZoneInColor;
            DiscomfortZoneOutColor = friendZonesConstantsCollector.discomfortZoneOutColor;
            DiscomfortZoneInColor = friendZonesConstantsCollector.discomfortZoneInColor;
            ComfortZoneOutColor = friendZonesConstantsCollector.comfortZoneOutColor;
            ComfortZoneInColor = friendZonesConstantsCollector.comfortZoneInColor;
            DistantZoneOutColor = friendZonesConstantsCollector.distantZoneOutColor;
            DistantZoneInColor = friendZonesConstantsCollector.distantZoneInColor;
        }
    }
}