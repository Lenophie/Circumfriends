using System.Collections;
using Dialogues;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers {
    public static class ScenesManager {
        public static DialogueGraph InitialDialogueGraph { get; private set; }

        /**
         * This method asynchronously loads a scene given its name
         * To be used as a coroutine
         */
        public static IEnumerator LoadScene(string sceneName) {
            AsyncOperation asyncLoading = SceneManager.LoadSceneAsync(sceneName);
            while (!asyncLoading.isDone) yield return null;
        }

        /**
         * Sets the initial dialogue graph used during the next scene loading
         */
        public static void SetInitialDialogueGraph(DialogueGraph initialDialogueGraph) {
            InitialDialogueGraph = initialDialogueGraph;
        }
    }
}