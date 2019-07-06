using Constants;
using FriendZones.FriendZoneShapes;
using UnityEngine;

namespace FriendZones {
    public class FriendZoneShapeController {
        public Vector3[] OuterVertices { get; private set; }
        private IFriendZoneShape friendZoneShape;
        //TODO: Add lerping speed

        public FriendZoneShapeController (IFriendZoneShape friendZoneShape) {
            this.friendZoneShape = friendZoneShape;
            friendZoneShape.CalculateTargetOuterVertices();
            OuterVertices = friendZoneShape.TargetOuterVertices;
        }

        public void CalculateZoneOuterVertices() {
            friendZoneShape.CalculateTargetOuterVertices();

            Vector3[] lerpedPositions = new Vector3[FriendZonesConstants.NumberOfOuterVerticesPerFriendzone];
            for (int i = 0; i < FriendZonesConstants.NumberOfOuterVerticesPerFriendzone; i++)
                lerpedPositions[i] = new Vector3(
                    Mathf.Lerp(OuterVertices[i].x, friendZoneShape.TargetOuterVertices[i].x, Time.deltaTime),
                    Mathf.Lerp(OuterVertices[i].y, friendZoneShape.TargetOuterVertices[i].y, Time.deltaTime),
                    0f);

            OuterVertices = lerpedPositions;
        }

        public void TransitionToNewCharacteristics(FriendZoneShapeConfigForm friendZoneShapeConfigForm) {
            switch (friendZoneShapeConfigForm.friendZoneShapesEnum) {
                case FriendZoneShapesEnum.Circle:
                    friendZoneShape =
                        new WavyFriendZoneShape(
                            // TODO: This cast errors
                            (CircleFriendZoneShapeConfig) friendZoneShapeConfigForm.friendZoneShapeConfig);
                    break;
                case FriendZoneShapesEnum.Wavy:
                    friendZoneShape =
                        new WavyFriendZoneShape(
                            friendZoneShapeConfigForm.friendZoneShapeConfig);
                    break;
                default:
                    break;
            }
        }
    }
}