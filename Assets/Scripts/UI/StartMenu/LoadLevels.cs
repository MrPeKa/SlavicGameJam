using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.UI.StartMenu
{
    public class LoadLevels : MonoBehaviour
    {
        public void LoadMainScene()
        {
            DevHelper.LevelLoader.Load(2);
        }

        public void LoadTestScene_Pawel()
        {
            DevHelper.LevelLoader.Load(3);
        }

        public void LoadTestScene_Przemek()
        {
            DevHelper.LevelLoader.Load(4);
        }

        public void LoadTestScene_Lukasz()
        {
            DevHelper.LevelLoader.Load(5);
        }

        public void LoadTestScene_Bartek()
        {
            DevHelper.LevelLoader.Load(6);
        }

        public void LoadTestScene_Michal()
        {
            DevHelper.LevelLoader.Load(7);
        }

        public void LoadTestScene_Youenn()
        {
            DevHelper.LevelLoader.Load(8);
        }

    }
}