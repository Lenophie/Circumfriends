using Constants;
using Controllers;
using Dialogues;
using Dialogues.Events;
using TMPro;
using UnityEngine;

namespace Managers {
    /**
     * This class handles the Main scene setup and serves as a router for events
     */
    public class GameManager : MonoBehaviour {
        [Header("Controllers")]
        [SerializeField] private MeController meController = default;
        [SerializeField] private FriendController friendController = default;
        [SerializeField] private FriendZonesController friendZonesController = default;

        [Header("Collectors")]
        [SerializeField] private FriendZonesConstantsCollector friendZonesConstantsCollector = default;
        [SerializeField] private ModifiersCollector modifiersCollector = default;

        [Header("Dialogue")]
        [SerializeField] private DialogueGraph initialDialogueGraph = default;
        [SerializeField] private TextMeshProUGUI dialogueTextMesh = default;
        [SerializeField] private TextMeshProUGUI dialogueTimerTextMesh = default;
        [SerializeField] private Animator dialogueHeadshotAnimator = default;
        [SerializeField] private LanguagesEnum language = default;

        private InputManager inputManager;
        private DialogueManager dialogueManager;
        private DialogueGraph currentDialogueGraph;
        public GaugesDecisionMaker GaugesDecisionMaker { get; private set; }
        public ChatNodeCoroutinesManager ChatNodeCoroutinesManager { get; private set; }

        private void Start() {
            inputManager = new InputManager(meController);
            ChatNodeCoroutinesManager = gameObject.AddComponent<ChatNodeCoroutinesManager>();
            dialogueManager = new DialogueManager(dialogueTextMesh, dialogueTimerTextMesh, dialogueHeadshotAnimator,
                language, ChatNodeCoroutinesManager);
            currentDialogueGraph = null;

            Modifiers.SetConstants(modifiersCollector);
            FriendZonesConstants.SetConstants(friendZonesConstantsCollector);
            friendZonesController.InitializeFriendZones();

            if (initialDialogueGraph) SetDialogueGraph(initialDialogueGraph); // Set an initial dialogue graph from the inspector for easy access
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
                case DialogueEventsEnum.FriendAnimatorModification:
                    friendController.HandleFriendAnimatorModificationEvent(
                        (FriendAnimatorModificationEvent) dialogueEvent);
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
                case DialogueEventsEnum.InputsEnabling:
                    inputManager.HandleInputsEnablingEvent(
                        (InputsEnablingEvent) dialogueEvent);
                    break;
                case DialogueEventsEnum.Blink:
                    friendZonesController.HandleBlinkEvent(
                        (BlinkEvent) dialogueEvent);
                    break;
                case DialogueEventsEnum.GaugesDefill:
                    friendZonesController.HandleGaugesDefillEvent();
                    break;
                case DialogueEventsEnum.SceneChange:
                    HandleDialogueGraphEnd();
                    StartCoroutine(
                        ScenesManager.LoadScene(((SceneChangeEvent) dialogueEvent).nextSceneName));
                    break;
                case DialogueEventsEnum.DialogueChange:
                    HandleDialogueGraphEnd();
                    SetDialogueGraph(((DialogueChangeEvent) dialogueEvent).nextDialogue);
                    break;
                default:
                    return;
            }
        }

        private void Update() {
            inputManager.UpdateInputs();
            if (currentDialogueGraph) GaugesDecisionMaker.CheckForInterruptions();
        }

        private void SetDialogueGraph(DialogueGraph dialogueGraph) {
            currentDialogueGraph = initialDialogueGraph;
            dialogueGraph.Restart(this, dialogueManager);
            GaugesDecisionMaker = new GaugesDecisionMaker(friendZonesController, dialogueGraph);
        }

        private void HandleDialogueGraphEnd() {
            currentDialogueGraph.Stop();
            currentDialogueGraph = null;
            GaugesDecisionMaker = null;
            ChatNodeCoroutinesManager.StopAllCoroutines();
        }
    }
}