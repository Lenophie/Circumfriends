using System.Collections;
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
        private bool isBlinking;

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

            UpdateColor(outColor);
        }

        private void UpdateColor(Color newColor) {
            if (meshRenderer) meshRenderer.material.color = newColor;
        }

        public IEnumerator Blink() {
            isBlinking = true;
            for (int i = 0; i < 5; i++) {
                UpdateColor(FriendZonesConstants.BlinkColor);
                yield return new WaitForSeconds(0.2f);
                UpdateColor(outColor);
                yield return new WaitForSeconds(0.2f);
            }

            isBlinking = false;
        }

        public void NotifyMeInZone() {
            if (!isBlinking) UpdateColor(inColor);
            Gauge?.IncrementFillRate();
        }

        public void NotifyMeExitingZone() {
            if (!isBlinking) UpdateColor(outColor);
        }
    }
}