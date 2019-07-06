using Constants;
using FriendZones.FriendZoneShapes;
using UnityEngine;

namespace FriendZones {
    public class FriendZone {
        public FriendZonesEnum FriendZoneEnum { get; }
        public IFriendZoneShape FriendZoneShape { get; }
        public LineRenderer LineRenderer { get; }
        public MeshCollider MeshCollider { get; }
        public MeshFilter MeshFilter { get; }

        private readonly MeshRenderer meshRenderer;
        private readonly Color outColor;
        private readonly Color inColor;

        public bool IsMeInZone { get; private set; }

        public FriendZone(FriendZonesEnum friendZoneEnum, IFriendZoneShape friendZoneShape,
            FriendZoneCollector friendZoneCollector) {
            FriendZoneEnum = friendZoneEnum;
            FriendZoneShape = friendZoneShape;
            LineRenderer = friendZoneCollector.lineRenderer;
            MeshCollider = friendZoneCollector.meshCollider;
            MeshFilter = friendZoneCollector.meshFilter;
            meshRenderer = friendZoneCollector.meshRenderer;
            FriendZoneListener friendZoneListener = friendZoneCollector.friendZoneListener;
            friendZoneListener.SetCorrespondingFriendZone(this);
            IsMeInZone = false;

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

            UpdateColor();
        }

        private void UpdateColor() {
            if (meshRenderer) meshRenderer.material.color = IsMeInZone ? inColor : outColor;
        }

        public void NotifyMeEnteringZone() {
            IsMeInZone = true;
            UpdateColor();
        }

        public void NotifyMeExitingZone() {
            IsMeInZone = false;
            UpdateColor();
        }
    }
}