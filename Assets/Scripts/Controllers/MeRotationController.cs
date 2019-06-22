using Constants;
using UnityEngine;

namespace Controllers {
    public class MeRotationController {
        private readonly Rigidbody2D friendRigidbody;
        private readonly Rigidbody2D meRigidbody;
        private float rotationSpeed;
        private bool isRotationClockwise;

        public MeRotationController(Rigidbody2D friendRigidbody, Rigidbody2D meRigidbody) {
            this.friendRigidbody = friendRigidbody;
            this.meRigidbody = meRigidbody;
            rotationSpeed = Modifiers.MeRotation;
            isRotationClockwise = true;
        }

        public void UpdateRotation() {
            Vector2 rotationDirection = Vector2.Perpendicular(friendRigidbody.position - meRigidbody.position);
            if (!isRotationClockwise) rotationDirection = -rotationDirection;
            meRigidbody.MovePosition(meRigidbody.position + rotationSpeed * Time.deltaTime * rotationDirection);
        }
    }
}