using UnityEngine;

namespace Assets.Scripts.Utilities.Scenes
{
    public class AutoLoadStartMenu : MonoBehaviour
    {
        void Update()
        {
            DevHelper.LevelLoader.GoToStartMenu();
        }
    }
}