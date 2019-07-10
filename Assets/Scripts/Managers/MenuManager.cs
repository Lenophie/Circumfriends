using UnityEngine;

namespace Managers {
    public class MenuManager : MonoBehaviour {
        public GameObject loadingGameObject;
        public void HandleStartPress() {
            loadingGameObject.SetActive(true);
            StartCoroutine(ScenesManager.LoadScene("Main"));
        }

        public void HandleTwitterPress() {
            Application.OpenURL("https://twitter.com/lenophie");
        }

        public void HandleGitHubPress() {
            Application.OpenURL("https://github.com/Lenophie/Circumfriends");
        }
    }
}