using Constants;
using Controllers;
using UnityEngine;

namespace Managers {
    public class GameManager : MonoBehaviour {
        [SerializeField] private MeController meController;
        [SerializeField] private ModifiersCollector modifiersCollector;
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