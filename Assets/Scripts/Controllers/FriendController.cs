using Dialogues.Events;
using UnityEngine;

namespace Controllers {
    public class FriendController : MonoBehaviour {
        [SerializeField] private Rigidbody friendRigidbody = default;
        [SerializeField] private Rigidbody meRigidbody = default;
        [SerializeField] private Animator friendAnimator = default;
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

        public void HandleFriendAnimatorModificationEvent(
            FriendAnimatorModificationEvent friendAnimatorModificationEvent) {
            friendAnimator.runtimeAnimatorController = friendAnimatorModificationEvent.friendAnimator;
        }
    }
}
