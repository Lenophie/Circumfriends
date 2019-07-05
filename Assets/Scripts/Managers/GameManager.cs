using Constants;
using Controllers;
using Dialogues;
using TMPro;
using UnityEngine;

namespace Managers {
    public class GameManager : MonoBehaviour {
        [Header("Controllers")]
        [SerializeField] private MeController meController = default;
        [SerializeField] private FriendZonesController friendZonesController = default;

        [Header("Collectors")]
        [SerializeField] private FriendZonesConstantsCollector friendZonesConstantsCollector = default;
        [SerializeField] private ModifiersCollector modifiersCollector = default;

        [Header("Dialogue")]
        [SerializeField] private DialogueGraph dialogueGraph = default;
        [SerializeField] private TextMeshProUGUI dialogueTextMesh = default;

        private InputManager inputManager;
        private DialogueManager dialogueManager;
        private void Start() {
            inputManager = new InputManager(meController);
            dialogueManager = new DialogueManager(dialogueTextMesh);

            Modifiers.SetConstants(modifiersCollector);
            FriendZonesConstants.SetConstants(friendZonesConstantsCollector);
            friendZonesController.InitializeFriendZones();
            dialogueGraph.Restart(this, dialogueManager);
            dialogueGraph.PickAnswerToCurrentChatNode(0);
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

        private void Update() {
            inputManager.UpdateInputs();
        }
    }
}