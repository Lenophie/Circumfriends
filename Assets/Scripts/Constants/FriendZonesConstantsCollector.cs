using System;
using UnityEngine;

namespace Constants {
    [Serializable]
    public class FriendZonesConstantsCollector {
        [Header("Parameters")]
        public int numberOfOuterVerticesPerFriendzone;
        public float maxLineNoiseAmplitude;

        [Header("Colors")]
        public Color noGoZoneOut;
        public Color noGoZoneIn;
        public Color discomfortZoneOut;
        public Color discomfortZoneIn;
        public Color comfortZoneOut;
        public Color comfortZoneIn;
        public Color distantZoneOut;
        public Color distantZoneIn;
    }
}