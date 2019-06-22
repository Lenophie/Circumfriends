using System;
using Controllers;
using Inputs;
using UnityEngine;

namespace Managers {
    public class InputManager : MonoBehaviour {
        [SerializeField] private MeController meController = default;

        private void Update() {
            PlayerInputs playerInputs = new PlayerInputs();
            meController.SetPlayerInputs(playerInputs);
        }
    }
}