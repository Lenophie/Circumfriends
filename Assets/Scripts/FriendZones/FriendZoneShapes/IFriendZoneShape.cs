using UnityEngine;

namespace FriendZones.FriendZoneShapes {
    public interface IFriendZoneShape {
        int NumberOfVertices { get; }
        Vector3[] OuterVertices { get; }
        void CalculateZoneOuterVertices();
    }
}