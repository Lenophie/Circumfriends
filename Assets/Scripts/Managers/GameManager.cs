using Constants;
using Controllers;
using UnityEngine;

namespace Managers {
    public class GameManager : MonoBehaviour {
        [Header("Controllers")]
        [SerializeField] private MeController meController = default;
        [SerializeField] private FriendZonesController friendZonesController = default;

        [Header("Collectors")]
        [SerializeField] private ModifiersCollector modifiersCollector = default;

        private InputManager inputManager;

        private void Start() {
            inputManager = new InputManager(meController);
            Modifiers.SetConstants(modifiersCollector);
            friendZonesController.InitializeFriendZones();
        }

        private void Update() {
            inputManager.UpdateInputs();
        }
    }
}