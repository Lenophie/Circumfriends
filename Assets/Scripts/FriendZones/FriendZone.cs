using Constants;
using FriendZones.FriendZoneShapes;
using UnityEngine;

namespace FriendZones {
    public class FriendZone {
        public FriendZonesEnum FriendZoneEnum { get; }
        public IFriendZoneShape FriendZoneShape { get; }
        public LineRenderer LineRenderer { get; }
        public PolygonCollider2D Collider { get; }
        public MeshFilter MeshFilter { get; }

        private readonly MeshRenderer meshRenderer;
        private readonly Color outColor;
        private readonly Color inColor;

        public FriendZone(FriendZonesEnum friendZoneEnum, IFriendZoneShape friendZoneShape,
            FriendZoneCollector friendZoneCollector) {
            FriendZoneEnum = friendZoneEnum;
            FriendZoneShape = friendZoneShape;
            LineRenderer = friendZoneCollector.lineRenderer;
            Collider = friendZoneCollector.collider;
            MeshFilter = friendZoneCollector.meshFilter;
            meshRenderer = friendZoneCollector.meshRenderer;

            switch (friendZoneEnum) {
                case FriendZonesEnum.NoGo:
                    outColor = FriendZonesConstants.NoGoZoneOut;
                    inColor = FriendZonesConstants.NoGoZoneIn;
                    break;
                case FriendZonesEnum.Discomfort:
                    outColor = FriendZonesConstants.DiscomfortZoneOut;
                    inColor = FriendZonesConstants.DiscomfortZoneIn;
                    break;
                case FriendZonesEnum.Comfort:
                    outColor = FriendZonesConstants.ComfortZoneOut;
                    inColor = FriendZonesConstants.ComfortZoneIn;
                    break;
                case FriendZonesEnum.Distant:
                    outColor = FriendZonesConstants.DistantZoneOut;
                    inColor = FriendZonesConstants.DistantZoneIn;
                    break;
            }

            UpdateColor(false);
        }

        public void UpdateColor(bool isMeIn) {
            if (meshRenderer) meshRenderer.material.color = isMeIn ? inColor : outColor;
        }
    }
}