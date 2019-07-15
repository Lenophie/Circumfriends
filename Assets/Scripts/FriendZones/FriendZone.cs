using System.Collections;
using Constants;
using FriendZones.FriendZoneShapes;
using UnityEngine;

namespace FriendZones {
    /**
     * This class holds the info and various handles for a given FriendZone
     * FriendZones are the areas between two limits in-game, they are distinguished by their colors
     */
    public class FriendZone {
        public FriendZonesEnum FriendZoneEnum { get; } // The name of the FriendZone
        public FriendZoneShapeController FriendZoneShapeController { get; } // The FriendZone's shape controller
        public LineRenderer LineRenderer { get; } // The FriendZone's outer line renderer
        public MeshCollider MeshCollider { get; } // The FriendZone's mesh collider
        public MeshFilter MeshFilter { get; } // The FriendZone's mesh filter

        public readonly Gauge Gauge; // The FriendZone's associated gauge
        private readonly MeshRenderer meshRenderer; // The FriendZone's mesh renderer
        private readonly Color outColor; // The color used when the player is out of the FriendZone
        private readonly Color inColor; // The color used when the player is in the FriendZone

        // TODO: Move to its own visuals-related class
        private bool isBlinking; // If true, the FriendZone is currently blinking. (effect used in the tutorial)

        public FriendZone(FriendZonesEnum friendZoneEnum, IFriendZoneShape friendZoneShape,
            FriendZoneCollector friendZoneCollector) {
            // Initialize attributes
            FriendZoneEnum = friendZoneEnum;
            FriendZoneShapeController = new FriendZoneShapeController(friendZoneShape);
            LineRenderer = friendZoneCollector.lineRenderer;
            MeshCollider = friendZoneCollector.meshCollider;
            MeshFilter = friendZoneCollector.meshFilter;

            Gauge = new Gauge();
            meshRenderer = friendZoneCollector.meshRenderer;

            // Initialize colors
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

            // Setup FriendZone listener's reference to this class
            FriendZoneListener friendZoneListener = friendZoneCollector.friendZoneListener;
            friendZoneListener.SetCorrespondingFriendZone(this);
        }

        // Changes the FriendZone's mesh color
        private void UpdateColor(Color newColor) {
            if (meshRenderer) meshRenderer.material.color = newColor;
        }

        // Coroutine used to make the FriendZone blink
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

        // Called by the FriendZone's listener when the player is in it
        public void NotifyMeInZone() {
            if (!isBlinking) UpdateColor(inColor);
            Gauge?.IncrementFillRate();
        }

        // Called by the FriendZone's listener when the player exits it
        public void NotifyMeExitingZone() {
            if (!isBlinking) UpdateColor(outColor);
        }
    }
}