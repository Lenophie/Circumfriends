using UnityEngine;

namespace FriendZones.FriendZoneShapes {
    public interface IFriendZoneShape {
        Vector3[] TargetOuterVertices { get; }
        void CalculateTargetOuterVertices();
    }
}