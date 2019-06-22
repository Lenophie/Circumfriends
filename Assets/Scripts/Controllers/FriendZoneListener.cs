using Constants;
using UnityEngine;

namespace Controllers {
    public class FriendZoneListener : MonoBehaviour {
        [SerializeField] private FriendZones zone = default;

        private void OnTriggerEnter2D(Collider2D other) {
            Debug.Log(zone);
        }
    }
}