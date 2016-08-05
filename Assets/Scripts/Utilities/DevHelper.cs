using Assets.Scripts.Utilities.Scenes;

namespace Assets.Scripts.Utilities
{
    public static class DevHelper
    {
        // Stored in a private member to avoid executing GetComponent everytime
        private static LevelLoader _levelLoader;
        public static LevelLoader LevelLoader
        {
            get
            {
                return _levelLoader ?? (_levelLoader = GetLevelLoader());
            }
        }

        // Methods below were made private so programmers only use the properties above!
        private static LevelLoader GetLevelLoader()
        {
            return new LevelLoader();
        }
    }
}