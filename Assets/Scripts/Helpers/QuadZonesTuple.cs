namespace Helpers {
    public class QuadZonesTuple<T> {
        public readonly T NoGo;
        public readonly T Discomfort;
        public readonly T Comfort;
        public readonly T Distant;

        public QuadZonesTuple(T noGo, T discomfort, T comfort, T distant) {
            NoGo = noGo;
            Discomfort = discomfort;
            Comfort = comfort;
            Distant = distant;
        }
    }
}