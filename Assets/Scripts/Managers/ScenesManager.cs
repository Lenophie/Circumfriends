using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers {
    public static class ScenesManager {
        public static IEnumerator LoadScene(string sceneName) {
            AsyncOperation asyncLoading = SceneManager.LoadSceneAsync(sceneName);

            while (!asyncLoading.isDone) yield return null;
            }
    }
}