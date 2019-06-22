using Constants;
using Controllers;
using UnityEngine;

namespace Managers {
    public class GameManager : MonoBehaviour {
        [SerializeField] private MeController meController = default;
        [SerializeField] private ModifiersCollector modifiersCollector = default;
        private InputManager inputManager;

        private void Start() {
            inputManager = new InputManager(meController);
            Modifiers.SetConstants(modifiersCollector);
        }

        private void Update() {
            inputManager.UpdateInputs();
        }
    }
}