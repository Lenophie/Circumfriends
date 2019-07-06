using Constants;
using UnityEngine;

namespace Controllers {
    public class FriendAttractionController {
        private readonly Rigidbody friendRigidbody;
        private readonly Rigidbody meRigidbody;
        private float attractionModifier;

        public FriendAttractionController(Rigidbody friendRigidbody, Rigidbody meRigidbody) {
            this.friendRigidbody = friendRigidbody;
            this.meRigidbody = meRigidbody;
            attractionModifier = Modifiers.FriendAttraction;
        }

        public void AttractMe() {
            meRigidbody.AddForce(
                attractionModifier * Time.deltaTime * (friendRigidbody.position - meRigidbody.position).normalized);
        }

        public void SetAttractionModifier(float attractionModifier) {
            this.attractionModifier = attractionModifier;
        }
    }
}