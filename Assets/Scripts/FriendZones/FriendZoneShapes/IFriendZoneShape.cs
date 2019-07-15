using UnityEngine;

namespace FriendZones.FriendZoneShapes {
    /**
     * The interface FriendZoneShapes must implement
     */
    public interface IFriendZoneShape {
        Vector3[] TargetOuterVertices { get; } // Access to the target outer vertices
        void CalculateTargetOuterVertices(); // Calculates the target outer vertices of the FriendZone's mesh
    }
}