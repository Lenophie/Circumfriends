using UnityEngine;

namespace Controllers {
    public class FriendAttractionController {
        private readonly Rigidbody2D friendRigidbody;
        private readonly Rigidbody2D meRigidbody;
        private float attractionModifier;

        public FriendAttractionController(Rigidbody2D friendRigidbody, Rigidbody2D meRigidbody) {
            this.friendRigidbody = friendRigidbody;
            this.meRigidbody = meRigidbody;
            attractionModifier = 10f;
        }

        public void AttractMe() {
            meRigidbody.AddForce((friendRigidbody.position - meRigidbody.position) * attractionModifier);
        }
    }
}