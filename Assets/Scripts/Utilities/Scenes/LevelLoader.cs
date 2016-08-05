using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Utilities.Scenes
{
    public class LevelLoader
    {
        public void Load(int levelId)
        {
            SceneManager.LoadScene(levelId);
        }

        public void GoToStartMenu()
        {
            var startMenuBuildIndex = 1;

            if (SceneManager.GetActiveScene().buildIndex == startMenuBuildIndex)
                return;

            SceneManager.LoadScene(startMenuBuildIndex);
        }
    }
}