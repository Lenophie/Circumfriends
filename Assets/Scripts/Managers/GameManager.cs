using Constants;
using UnityEngine;

namespace Managers {
    public class GameManager : MonoBehaviour {
        [SerializeField] private ModifiersCollector modifiersCollector;

        private void Start() {
            Modifiers.SetConstants(modifiersCollector);
        }
    }
}