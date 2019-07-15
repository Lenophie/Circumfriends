using System;
using Controllers;
using UnityEngine;

namespace FriendZones {
    /**
     * This class is used to serialize data for FriendZones
     */
    [Serializable]
    public class FriendZoneCollector {
        public LineRenderer lineRenderer;
        public MeshCollider meshCollider;
        public MeshFilter meshFilter;
        public MeshRenderer meshRenderer;
        public GaugeUIController gaugeUIController;
        public FriendZoneListener friendZoneListener;
    }
}