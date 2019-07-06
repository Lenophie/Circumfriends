using Dialogues.Events;
using UnityEngine;

namespace Controllers {
    public class FriendController : MonoBehaviour {
        [SerializeField] private Rigidbody2D friendRigidbody = default;
        [SerializeField] private Rigidbody2D meRigidbody = default;
        private FriendAttractionController friendAttractionController;

        private void Start() {
            friendAttractionController = new FriendAttractionController(friendRigidbody, meRigidbody);
        }

        private void Update() {
            friendAttractionController.AttractMe();
        }

        public void HandleFriendAttractionModificationEvent(
            FriendAttractionModificationEvent friendAttractionModificationEvent) {
            friendAttractionController.SetAttractionModifier(friendAttractionModificationEvent.attraction);
        }
    }
}
