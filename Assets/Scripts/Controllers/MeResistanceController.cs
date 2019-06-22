using UnityEngine;

namespace Controllers {
    public class MeResistanceController {
        private readonly Rigidbody2D friendRigidbody;
        private readonly Rigidbody2D meRigidbody;
        private float resistanceModifier;

        public MeResistanceController(Rigidbody2D friendRigidbody, Rigidbody2D meRigidbody) {
            this.friendRigidbody = friendRigidbody;
            this.meRigidbody = meRigidbody;
            resistanceModifier = 1400f;
        }

        public void UpdateResistance(float resistanceInput) {
            meRigidbody.AddForce((meRigidbody.position - friendRigidbody.position) * resistanceInput * Time.deltaTime *
                                 resistanceModifier);
        }
    }
}