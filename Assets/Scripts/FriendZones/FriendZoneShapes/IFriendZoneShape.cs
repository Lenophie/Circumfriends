using UnityEngine;

namespace FriendZones.FriendZoneShapes {
    public interface IFriendZoneShape {
        Vector3[] OuterVertices { get; }
        void CalculateZoneOuterVertices();
    }
}