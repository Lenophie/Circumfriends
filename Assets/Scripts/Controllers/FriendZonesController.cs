using System.Collections.Generic;
using Constants;
using Dialogues.Events;
using FriendZones;
using FriendZones.FriendZoneShapes;
using Helpers;
using Meshes;
using UnityEngine;

namespace Controllers {
    public class FriendZonesController : MonoBehaviour {
        public QuadZonesTuple<FriendZone> FriendZones { get; private set; }

        [SerializeField] private FriendZoneCollector noGoFriendZoneCollector = default;
        [SerializeField] private FriendZoneCollector discomfortFriendZoneCollector = default;
        [SerializeField] private FriendZoneCollector comfortFriendZoneCollector = default;
        [SerializeField] private FriendZoneCollector distantFriendZoneCollector = default;

        public void InitializeFriendZones() {
            // Regroup friendzone collectors
            QuadZonesTuple<FriendZoneCollector> friendZonesCollectors =
                new QuadZonesTuple<FriendZoneCollector>(
                    noGoFriendZoneCollector,
                    discomfortFriendZoneCollector,
                    comfortFriendZoneCollector,
                    distantFriendZoneCollector);

            // Initialize friendzones with collectors' info
            FriendZones = new QuadZonesTuple<FriendZone>(
                new FriendZone(
                    FriendZonesEnum.NoGo,
                    new WavyFriendZoneShape(new CircleFriendZoneShapeConfig(2f)),
                    friendZonesCollectors.NoGo),
                new FriendZone(
                    FriendZonesEnum.Discomfort,
                    new WavyFriendZoneShape(new CircleFriendZoneShapeConfig(4f)),
                    friendZonesCollectors.Discomfort),
                new FriendZone(
                    FriendZonesEnum.Comfort,
                    new WavyFriendZoneShape(new CircleFriendZoneShapeConfig(6f)),
                    friendZonesCollectors.Comfort),
                new FriendZone(
                    FriendZonesEnum.Distant,
                    new WavyFriendZoneShape(new CircleFriendZoneShapeConfig(8f)),
                    friendZonesCollectors.Distant)
            );

            // TODO: Generate UI elements instead of referencing them
            if (friendZonesCollectors.NoGo.gaugeUIController) {
                friendZonesCollectors.NoGo.gaugeUIController.SetGauge(FriendZones.NoGo.Gauge,
                    FriendZonesConstants.NoGoZoneInColor);
            }

            if (friendZonesCollectors.Discomfort.gaugeUIController) {
                friendZonesCollectors.Discomfort.gaugeUIController.SetGauge(FriendZones.Discomfort.Gauge,
                    FriendZonesConstants.DiscomfortZoneInColor);
            }

            if (friendZonesCollectors.Comfort.gaugeUIController) {
                friendZonesCollectors.Comfort.gaugeUIController.SetGauge(FriendZones.Comfort.Gauge,
                    FriendZonesConstants.ComfortZoneInColor);
            }

            if (friendZonesCollectors.Distant.gaugeUIController) {
                friendZonesCollectors.Distant.gaugeUIController.SetGauge(FriendZones.Distant.Gauge,
                    FriendZonesConstants.DistantZoneInColor);
            }
        }

        private void Update() {
            BuildZone(FriendZones.NoGo);
            BuildZone(FriendZones.Discomfort);
            BuildZone(FriendZones.Comfort);
            BuildZone(FriendZones.Distant);
        }

        private void BuildZone(FriendZone friendZone) {
            friendZone.FriendZoneShapeController.CalculateZoneOuterVertices();

            if (friendZone.LineRenderer) {
                friendZone.LineRenderer.positionCount = FriendZonesConstants.NumberOfOuterVerticesPerFriendzone;
                friendZone.LineRenderer.SetPositions(
                    Noisifier.NoisifySmoothVectors(friendZone.FriendZoneShapeController.OuterVertices, 4));
            }

            List<Vector2> zonePositions2D = new List<Vector2>();
            for (int i = 0; i < FriendZonesConstants.NumberOfOuterVerticesPerFriendzone; i++)
                zonePositions2D.Add(friendZone.FriendZoneShapeController.OuterVertices[i]);

            if (friendZone.FriendZoneEnum == FriendZonesEnum.NoGo) {
                Mesh mesh = new Mesh {vertices = friendZone.FriendZoneShapeController.OuterVertices};
                int[] triangles = Triangulator.TriangulateConcave(zonePositions2D);
                mesh.triangles = triangles;
                if (friendZone.MeshFilter) friendZone.MeshFilter.mesh = mesh;
                if (friendZone.MeshCollider) friendZone.MeshCollider.sharedMesh = mesh;
            } else {
                Vector3[] previousZonePositions;
                switch (friendZone.FriendZoneEnum) {
                    case FriendZonesEnum.Discomfort:
                        previousZonePositions = FriendZones.NoGo.FriendZoneShapeController.OuterVertices;
                        break;
                    case FriendZonesEnum.Comfort:
                        previousZonePositions = FriendZones.Discomfort.FriendZoneShapeController.OuterVertices;
                        break;
                    case FriendZonesEnum.Distant:
                        previousZonePositions = FriendZones.Comfort.FriendZoneShapeController.OuterVertices;
                        break;
                    default:
                        previousZonePositions = new Vector3[0];
                        break;
                }

                Vector3[] meshPositions = new Vector3[2 * FriendZonesConstants.NumberOfOuterVerticesPerFriendzone];
                for (int i = 0; i < FriendZonesConstants.NumberOfOuterVerticesPerFriendzone; i++) {
                    meshPositions[i] = previousZonePositions[i];
                    meshPositions[FriendZonesConstants.NumberOfOuterVerticesPerFriendzone + i] =
                        friendZone.FriendZoneShapeController.OuterVertices[i];
                }

                Mesh mesh = new Mesh {
                    vertices = meshPositions,
                    triangles = Triangulator.TriangulateRing(FriendZonesConstants.NumberOfOuterVerticesPerFriendzone)
                };
                if (friendZone.MeshFilter) friendZone.MeshFilter.mesh = mesh;
                if (friendZone.MeshCollider) friendZone.MeshCollider.sharedMesh = mesh;
            }
        }

        public void HandleFriendZoneShapeModificationEvent(FriendZoneShapeModificationEvent friendZoneShapeModificationEvent) {
            FriendZone friendZoneToModify = EnumToFriendZone(friendZoneShapeModificationEvent.friendZonesEnum);
            friendZoneToModify.FriendZoneShapeController.TransitionToNewCharacteristics(friendZoneShapeModificationEvent
                .friendZoneShapeConfigForm);
        }

        public void HandleGaugesModificationEvent(GaugesModificationEvent gaugesModificationEvent) {
            foreach (GaugeModificationEvent gaugeModificationEvent in gaugesModificationEvent.gaugeModificationEvents) {
                FriendZone friendZoneToModify = EnumToFriendZone(gaugeModificationEvent.friendZonesEnum);
                friendZoneToModify.Gauge.ChangeMaxHeight(gaugeModificationEvent.maxHeight);
                friendZoneToModify.Gauge.ChangeFillRateSpeed(gaugeModificationEvent.fillRateSpeed);
            }
        }

        public void HandleBlinkEvent(BlinkEvent blinkEvent) {
            FriendZone friendZoneToBlink = EnumToFriendZone(blinkEvent.friendZonesEnum);
            StartCoroutine(friendZoneToBlink.Blink());
        }

        public FriendZone EnumToFriendZone(FriendZonesEnum? friendZonesEnum) {
            switch (friendZonesEnum) {
                case FriendZonesEnum.NoGo:
                    return FriendZones.NoGo;
                case FriendZonesEnum.Discomfort:
                    return FriendZones.Discomfort;
                case FriendZonesEnum.Comfort:
                    return FriendZones.Comfort;
                case FriendZonesEnum.Distant:
                    return FriendZones.Distant;
                default:
                    return null;
            }
        }
    }
}
