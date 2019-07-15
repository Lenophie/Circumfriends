using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers {
    public static class ScenesManager {
        /**
         * This method asynchronously loads a scene given its name
         * To be used as a coroutine
         */
        public static IEnumerator LoadScene(string sceneName) {
            AsyncOperation asyncLoading = SceneManager.LoadSceneAsync(sceneName);
            while (!asyncLoading.isDone) yield return null;
        }
    }
}