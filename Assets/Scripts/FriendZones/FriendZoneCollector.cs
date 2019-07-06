using System;
using UnityEngine;

namespace FriendZones {
    [Serializable]
    public class FriendZoneCollector {
        public LineRenderer lineRenderer;
        public MeshCollider meshCollider;
        public MeshFilter meshFilter;
        public MeshRenderer meshRenderer;
        public FriendZoneListener friendZoneListener;
    }
}