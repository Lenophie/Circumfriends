using System.Collections;
using Constants;
using Controllers;
using FriendZones.FriendZoneShapes;
using UnityEngine;

namespace Managers {
    public class GameManager : MonoBehaviour {
        [Header("Controllers")]
        [SerializeField] private MeController meController = default;
        [SerializeField] private FriendZonesController friendZonesController = default;

        [Header("Collectors")]
        [SerializeField] private FriendZonesConstantsCollector friendZonesConstantsCollector = default;
        [SerializeField] private ModifiersCollector modifiersCollector = default;

        private InputManager inputManager;

        private void Start() {
            inputManager = new InputManager(meController);
            Modifiers.SetConstants(modifiersCollector);
            FriendZonesConstants.SetConstants(friendZonesConstantsCollector);
            friendZonesController.InitializeFriendZones();
            StartCoroutine(TransitionTester());
        }

        private IEnumerator TransitionTester() { // TODO: Remove this
            yield return new WaitForSeconds(5f);
            friendZonesController.FriendZones.Comfort.FriendZoneShape.TransitionToNewCharacteristics(new FriendZoneShapeConfig(
                6f, 0.1f, 3f));
        }

        private void Update() {
            inputManager.UpdateInputs();
        }
    }
}