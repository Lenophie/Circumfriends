using System;
using UnityEngine;

namespace FriendZones {
    [Serializable]
    public class FriendZoneCollector {
        public LineRenderer lineRenderer;
        public PolygonCollider2D collider;
        public MeshFilter meshFilter;
        public MeshRenderer meshRenderer;
    }
}