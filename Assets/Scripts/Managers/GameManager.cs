using System.Collections;
using Constants;
using Controllers;
using Dialogues;
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
        [Header("Dialogue")]
        [SerializeField] private DialogueGraph dialogueGraph = default;

        private void Start() {
            inputManager = new InputManager(meController);
            Modifiers.SetConstants(modifiersCollector);
            FriendZonesConstants.SetConstants(friendZonesConstantsCollector);
            friendZonesController.InitializeFriendZones();
            StartCoroutine(TransitionTester());
            DialogueTester();
        }

        private IEnumerator TransitionTester() { // TODO: Remove this
            yield return new WaitForSeconds(5f);
            friendZonesController.FriendZones.Comfort.FriendZoneShape.TransitionToNewCharacteristics(new FriendZoneShapeConfig(
                6f, 0.1f, 3f));
            yield return new WaitForSeconds(1f);
            friendZonesController.FriendZones.Discomfort.FriendZoneShape.TransitionToNewCharacteristics(new FriendZoneShapeConfig(
                3f, 0.05f, 8f));
            yield return new WaitForSeconds(2f);
            friendZonesController.FriendZones.Comfort.FriendZoneShape.TransitionToNewCharacteristics(new FriendZoneShapeConfig(
                4f, 0.05f, 20f));
        }

        public void HandleDialogueEvent(DialogueEventsEnum dialogueEventsEnum, DialogueEvent dialogueEvent) {
            Debug.Log(dialogueEventsEnum);
            Debug.Log(((FriendZoneShapeModificationEvent) dialogueEvent).friendZoneShapeConfig.radius);
        }
        
        private void DialogueTester() { // TODO: remove this
            dialogueGraph.Restart(this);
            Debug.Log(dialogueGraph.currentChatNode.text);
            dialogueGraph.PickAnswerToCurrentChatNode(0);
            Debug.Log(dialogueGraph.currentChatNode.text);
        }

        private void Update() {
            inputManager.UpdateInputs();
        }
    }
}