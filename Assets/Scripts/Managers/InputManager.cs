using Controllers;
using Dialogues.Events;
using Inputs;

namespace Managers {
    public class InputManager {
        private readonly MeController meController;
        private bool areInputsEnabled;

        public InputManager(MeController meController) {
            this.meController = meController;
            areInputsEnabled = false;
        }
        public void UpdateInputs() {
            PlayerInputs playerInputs = areInputsEnabled ? new PlayerInputs() : PlayerInputs.GetDisabledInputs();
            meController.SetPlayerInputs(playerInputs);
        }

        public void HandleInputsEnablingEvent(InputsEnablingEvent inputsEnablingEvent) {
            areInputsEnabled = inputsEnablingEvent.enableInputs;
        }
    }
}