using Constants;
using UnityEngine;

namespace Controllers {
    public class MeRotationController {
        private readonly Rigidbody friendRigidbody;
        private readonly Rigidbody meRigidbody;
        private float rotationSpeed;
        private bool isRotationClockwise;

        public MeRotationController(Rigidbody friendRigidbody, Rigidbody meRigidbody) {
            this.friendRigidbody = friendRigidbody;
            this.meRigidbody = meRigidbody;
            rotationSpeed = Modifiers.MeRotation;
            isRotationClockwise = true;
        }

        public Vector2 GetInitialRotation() {
            Vector2 rotationDirection =
                Vector2.Perpendicular(friendRigidbody.position - meRigidbody.position).normalized;
            if (!isRotationClockwise) rotationDirection = -rotationDirection;
            return rotationSpeed * rotationDirection;
        }

        public void SetSpeedModifier(float rotationSpeed, bool isRotationClockwise) {
            this.rotationSpeed = rotationSpeed;
            this.isRotationClockwise = isRotationClockwise;
        }
    }
}