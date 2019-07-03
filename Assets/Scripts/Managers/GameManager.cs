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
            dialogueGraph.Restart(this);
            StartCoroutine(DialogueTester());
        }

        public void HandleDialogueEvent(DialogueEventsEnum dialogueEventsEnum, DialogueEvent dialogueEvent) {
            switch (dialogueEventsEnum) {
                case DialogueEventsEnum.FriendZoneShapeModification:
                    friendZonesController.HandleFriendZoneShapeModificationEvent(
                        (FriendZoneShapeModificationEvent) dialogueEvent);
                    break;
                default:
                    return;
            }
        }

        private IEnumerator DialogueTester() { // TODO: remove this
            yield return new WaitForSeconds(5f);
            dialogueGraph.PickAnswerToCurrentChatNode(0);
            yield return new WaitForSeconds(1f);
            dialogueGraph.PickAnswerToCurrentChatNode(0);
            yield return new WaitForSeconds(2f);
            dialogueGraph.PickAnswerToCurrentChatNode(0);
        }

        private void Update() {
            inputManager.UpdateInputs();
        }
    }
}