namespace Constants {
    public static class FriendZonesConstants {
        public static int NumberOfOuterVerticesPerFriendzone { get; private set; }
        public static float MaxLineNoiseAmplitude { get; private set; }

        public static void SetConstants(FriendZonesConstantsCollector friendZonesConstantsCollector) {
            NumberOfOuterVerticesPerFriendzone = friendZonesConstantsCollector.numberOfOuterVerticesPerFriendzone;
            MaxLineNoiseAmplitude = friendZonesConstantsCollector.maxLineNoiseAmplitude;
        }
    }
}