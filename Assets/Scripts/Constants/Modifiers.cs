namespace Constants {
    public static class Modifiers {
        public static float MeRotation { get; private set; }
        public static float MeResistance { get; private set; }
        public static float FriendAttraction { get; private set; }

        public static void SetConstants(ModifiersCollector modifiersCollector) {
            MeRotation = modifiersCollector.meRotation;
            MeResistance = modifiersCollector.meResistance;
            FriendAttraction = modifiersCollector.friendAttraction;
        }
    }
}