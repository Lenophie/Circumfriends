using Constants;
using FriendZones.FriendZoneShapes;
using UnityEngine;

namespace FriendZones {
    public class FriendZone {
        public FriendZonesEnum FriendZoneEnum { get; }
        public FriendZoneShapeController FriendZoneShapeController { get; }
        public LineRenderer LineRenderer { get; }
        public MeshCollider MeshCollider { get; }
        public MeshFilter MeshFilter { get; }

        public readonly Gauge Gauge;
        private readonly MeshRenderer meshRenderer;
        private readonly Color outColor;
        private readonly Color inColor;

        private bool isMeInZone;

        public FriendZone(FriendZonesEnum friendZoneEnum, IFriendZoneShape friendZoneShape,
            FriendZoneCollector friendZoneCollector) {
            FriendZoneEnum = friendZoneEnum;
            FriendZoneShapeController = new FriendZoneShapeController(friendZoneShape);
            Gauge = new Gauge();
            LineRenderer = friendZoneCollector.lineRenderer;
            MeshCollider = friendZoneCollector.meshCollider;
            MeshFilter = friendZoneCollector.meshFilter;
            meshRenderer = friendZoneCollector.meshRenderer;
            FriendZoneListener friendZoneListener = friendZoneCollector.friendZoneListener;
            friendZoneListener.SetCorrespondingFriendZone(this);
            isMeInZone = false;

            switch (friendZoneEnum) {
                case FriendZonesEnum.NoGo:
                    outColor = FriendZonesConstants.NoGoZoneOutColor;
                    inColor = FriendZonesConstants.NoGoZoneInColor;
                    break;
                case FriendZonesEnum.Discomfort:
                    outColor = FriendZonesConstants.DiscomfortZoneOutColor;
                    inColor = FriendZonesConstants.DiscomfortZoneInColor;
                    break;
                case FriendZonesEnum.Comfort:
                    outColor = FriendZonesConstants.ComfortZoneOutColor;
                    inColor = FriendZonesConstants.ComfortZoneInColor;
                    break;
                case FriendZonesEnum.Distant:
                    outColor = FriendZonesConstants.DistantZoneOutColor;
                    inColor = FriendZonesConstants.DistantZoneInColor;
                    break;
            }

            UpdateColor();
        }

        private void UpdateColor() {
            if (meshRenderer) meshRenderer.material.color = isMeInZone ? inColor : outColor;
        }

        public void NotifyMeInZone() {
            isMeInZone = true;
            UpdateColor();
            Gauge?.IncrementFillRate();
        }

        public void NotifyMeExitingZone() {
            isMeInZone = false;
            UpdateColor();
        }
    }
}