using Constants;
using FriendZones.FriendZoneShapes;
using UnityEngine;

namespace FriendZones {
    /**
     * This class controls the shape of a FriendZone
     */
    public class FriendZoneShapeController {
        public Vector3[] OuterVertices { get; private set; } // The FriendZone's current outer vertices (used by the mesh)
        private IFriendZoneShape friendZoneShape; // The FriendZone's shape
        //TODO: Add lerping speed

        public FriendZoneShapeController (IFriendZoneShape friendZoneShape) {
            this.friendZoneShape = friendZoneShape;
            friendZoneShape.CalculateTargetOuterVertices();
            OuterVertices = friendZoneShape.TargetOuterVertices;
        }

        /**
         * Calculates the FriendZone's outer vertices
         * They are calculated by lerping between the current outer vertices and the target outer vertices from the FriendZone shape
         */
        public void CalculateZoneOuterVertices() {
            // Calculate the FriendZone shape's target outer vertices
            friendZoneShape.CalculateTargetOuterVertices();

            // Lerp between current and target outer vertices
            Vector3[] lerpedPositions = new Vector3[FriendZonesConstants.NumberOfOuterVerticesPerFriendzone];
            for (int i = 0; i < FriendZonesConstants.NumberOfOuterVerticesPerFriendzone; i++)
                lerpedPositions[i] = new Vector3(
                    Mathf.Lerp(OuterVertices[i].x, friendZoneShape.TargetOuterVertices[i].x, Time.deltaTime),
                    Mathf.Lerp(OuterVertices[i].y, friendZoneShape.TargetOuterVertices[i].y, Time.deltaTime),
                    0f);

            // Set new outer vertices
            OuterVertices = lerpedPositions;
        }

        /**
         * Handles the transition to a new shape
         */
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