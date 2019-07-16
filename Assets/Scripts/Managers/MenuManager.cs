using UnityEngine;

namespace Managers {
    /**
     * This class handles the Menu buttons presses
     */
    public class MenuManager : MonoBehaviour {
        public GameObject tutorialLoadingGameObject;
        public GameObject startLoadingGameObject;

        /**
         * Handles a press on the Tutorial button
         */
        public void HandleTutorialPress() {
            tutorialLoadingGameObject.SetActive(true);
            StartCoroutine(ScenesManager.LoadScene("Main"));
        }

        /**
         * Handles a press on the Start button
         */
        public void HandleStartPress() {
            startLoadingGameObject.SetActive(true);
            StartCoroutine(ScenesManager.LoadScene("Main"));
        }

        /**
         * Handles a press on the Twitter button
         */
        public void HandleTwitterPress() {
            Application.OpenURL("https://twitter.com/lenophie");
        }

        /**
         * Handles a press on the GitHub button
         */
        public void HandleGitHubPress() {
            Application.OpenURL("https://github.com/Lenophie/Circumfriends");
        }
    }
}