using Controllers;
using Inputs;

namespace Managers {
    public class InputManager {
        private readonly MeController meController;

        public InputManager(MeController meController) {
            this.meController = meController;
        }
        public void UpdateInputs() {
            PlayerInputs playerInputs = new PlayerInputs();
            meController.SetPlayerInputs(playerInputs);
        }
    }
}