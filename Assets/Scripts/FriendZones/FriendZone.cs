using Constants;
using FriendZoneShapes;
using UnityEngine;

namespace FriendZones {
    public class FriendZone {
        public FriendZonesEnum FriendZoneEnum { get; }
        public IFriendZoneShape FriendZoneShape { get; }
        public LineRenderer LineRenderer { get; }
        public PolygonCollider2D Collider { get; }
        public MeshFilter MeshFilter { get; }

        public FriendZone(FriendZonesEnum friendZoneEnum, IFriendZoneShape friendZoneShape,
            FriendZoneCollector friendZoneCollector) {
            FriendZoneEnum = friendZoneEnum;
            FriendZoneShape = friendZoneShape;
            LineRenderer = friendZoneCollector.lineRenderer;
            Collider = friendZoneCollector.collider;
            MeshFilter = friendZoneCollector.meshFilter;
        }
    }
}