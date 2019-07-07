using Constants;
using Controllers;
using Dialogues;
using Dialogues.Events;
using TMPro;
using UnityEngine;

namespace Managers {
    public class GameManager : MonoBehaviour {
        [Header("Controllers")]
        [SerializeField] private MeController meController = default;
        [SerializeField] private FriendController friendController = default;
        [SerializeField] private FriendZonesController friendZonesController = default;

        [Header("Collectors")]
        [SerializeField] private FriendZonesConstantsCollector friendZonesConstantsCollector = default;
        [SerializeField] private ModifiersCollector modifiersCollector = default;

        [Header("Dialogue")]
        [SerializeField] private DialogueGraph dialogueGraph = default;
        [SerializeField] private TextMeshProUGUI dialogueTextMesh = default;
        [SerializeField] private Animator dialogueHeadshotAnimator = default;
        [SerializeField] private LanguagesEnum language = default;

        private InputManager inputManager;
        private DialogueManager dialogueManager;

        private void Start() {
            inputManager = new InputManager(meController);
            dialogueManager = new DialogueManager(dialogueTextMesh, dialogueHeadshotAnimator, language, this);

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
                case DialogueEventsEnum.FriendAttractionModification:
                    friendController.HandleFriendAttractionModificationEvent(
                        (FriendAttractionModificationEvent) dialogueEvent);
                    break;
                case DialogueEventsEnum.MeResistanceModification:
                    meController.HandleMeResistanceModificationEvent(
                        (MeResistanceModificationEvent) dialogueEvent);
                    break;
                case DialogueEventsEnum.MeSpeedModification:
                    meController.HandleMeSpeedModificationEvent(
                        (MeSpeedModificationEvent) dialogueEvent);
                    break;
                case DialogueEventsEnum.GaugesModification:
                    friendZonesController.HandleGaugesModificationEvent(
                        (GaugesModificationEvent) dialogueEvent);
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