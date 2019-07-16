using Constants;
using UnityEngine;

namespace Controllers {
    public class MeResistanceController {
        private readonly Rigidbody friendRigidbody;
        private readonly Rigidbody meRigidbody;
        private float resistanceModifier;

        public MeResistanceController(Rigidbody friendRigidbody, Rigidbody meRigidbody) {
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

        public Vector2 GetCurrentNormalVelocity() {
            return Vector3.Project(meRigidbody.velocity,
                (friendRigidbody.position - meRigidbody.position).normalized);
            ;
        }
    }
}