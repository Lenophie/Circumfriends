using Constants;
using UnityEngine;

namespace Controllers {
    public class MeResistanceController {
        private readonly Rigidbody2D friendRigidbody;
        private readonly Rigidbody2D meRigidbody;
        private float resistanceModifier;

        public MeResistanceController(Rigidbody2D friendRigidbody, Rigidbody2D meRigidbody) {
            this.friendRigidbody = friendRigidbody;
            this.meRigidbody = meRigidbody;
            resistanceModifier = Modifiers.MeResistance;
        }

        public void UpdateResistance(float resistanceInput) {
            meRigidbody.AddForce(resistanceInput * Time.deltaTime * resistanceModifier *
                                 (meRigidbody.position - friendRigidbody.position).normalized);
        }

        public void SetResistanceModifier(float resistanceModifier) {
            this.resistanceModifier = resistanceModifier;
        }
    }
}