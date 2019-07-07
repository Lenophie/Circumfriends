using System;
using UnityEngine;

namespace Constants {
    [Serializable]
    public class FriendZonesConstantsCollector {
        [Header("Parameters")]
        public int numberOfOuterVerticesPerFriendzone;
        public float maxLineNoiseAmplitude;

        [Header("Colors")]
        public Color noGoZoneOutColor;
        public Color noGoZoneInColor;
        public Color discomfortZoneOutColor;
        public Color discomfortZoneInColor;
        public Color comfortZoneOutColor;
        public Color comfortZoneInColor;
        public Color distantZoneOutColor;
        public Color distantZoneInColor;
        public Color blinkColor;
    }
}