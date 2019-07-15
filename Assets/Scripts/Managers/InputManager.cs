using Controllers;
using Dialogues.Events;
using Inputs;

namespace Managers {
    /**
     * This class listens the player inputs and sends them to the appropriate controller
     */
    public class InputManager {
        private readonly MeController meController;  // Controller of the player character
        private bool areInputsEnabled;               // True if inputs are enabled, false otherwise

        public InputManager(MeController meController) {
            this.meController = meController;
            areInputsEnabled = false;
        }

        /*
         * This method is called to collect player inputs and send them to the player controller
         */
        public void UpdateInputs() {
            PlayerInputs playerInputs = areInputsEnabled ? new PlayerInputs() : PlayerInputs.GetDisabledInputs();
            meController.SetPlayerInputs(playerInputs);
        }

        /**
         * This method enables or disables inputs based on an incoming InputsEnablingEvent
         */
        public void HandleInputsEnablingEvent(InputsEnablingEvent inputsEnablingEvent) {
            areInputsEnabled = inputsEnablingEvent.enableInputs;
        }
    }
}