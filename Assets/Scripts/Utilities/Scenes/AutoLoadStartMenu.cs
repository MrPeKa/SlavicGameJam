using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Utilities.Scenes
{
    public class AutoLoadStartMenu : MonoBehaviour
    {
        void Update()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
                DevHelper.LevelLoader.GoToStartMenu();
            else
                gameObject.SetActive(false);
        }
    }
}