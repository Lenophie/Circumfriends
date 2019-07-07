using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers {
    public class MenuManager : MonoBehaviour {
        public void HandleStartPress() {
            SceneManager.LoadScene("Main");
        }
    }
}