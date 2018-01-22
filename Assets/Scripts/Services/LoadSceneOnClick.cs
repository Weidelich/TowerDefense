using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Services
{
    public class LoadSceneOnClick : MonoBehaviour
    {
        public void LoadByIndex(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }

        public void LoadByName(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
