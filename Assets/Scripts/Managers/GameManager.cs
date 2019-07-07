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
        [SerializeField] private TextMeshProUGUI dialogueTimerTextMesh = default;
        [SerializeField] private Animator dialogueHeadshotAnimator = default;
        [SerializeField] private LanguagesEnum language = default;

        private InputManager inputManager;
        private DialogueManager dialogueManager;
        public GaugesDecisionMaker GaugesDecisionMaker { get; private set; }
        public ChatNodeCoroutinesManager ChatNodeCoroutinesManager { get; private set; }

        private void Start() {
            inputManager = new InputManager(meController);
            ChatNodeCoroutinesManager = gameObject.AddComponent<ChatNodeCoroutinesManager>();
            dialogueManager = new DialogueManager(dialogueTextMesh, dialogueTimerTextMesh, dialogueHeadshotAnimator,
                language, ChatNodeCoroutinesManager);

            Modifiers.SetConstants(modifiersCollector);
            FriendZonesConstants.SetConstants(friendZonesConstantsCollector);
            friendZonesController.InitializeFriendZones();
            dialogueGraph.Restart(this, dialogueManager);
            GaugesDecisionMaker = new GaugesDecisionMaker(friendZonesController, dialogueGraph);
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