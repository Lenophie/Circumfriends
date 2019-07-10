using UnityEngine.SceneManagement;

namespace Managers {
    public static class ScenesManager {
        public static void LoadScene(string sceneName) {
            SceneManager.LoadScene(sceneName);
        }
    }
}