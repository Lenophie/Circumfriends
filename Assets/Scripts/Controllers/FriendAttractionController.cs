using Constants;
using UnityEngine;

namespace Controllers {
    public class FriendAttractionController {
        private readonly Rigidbody2D friendRigidbody;
        private readonly Rigidbody2D meRigidbody;
        private float attractionModifier;

        public FriendAttractionController(Rigidbody2D friendRigidbody, Rigidbody2D meRigidbody) {
            this.friendRigidbody = friendRigidbody;
            this.meRigidbody = meRigidbody;
            attractionModifier = Modifiers.FriendAttraction;
        }

        public void AttractMe() {
            meRigidbody.AddForce(
                attractionModifier * Time.deltaTime * (friendRigidbody.position - meRigidbody.position).normalized);
        }
    }
}