using Assets.Scripts.Utilities.Scenes;
using System;

namespace Assets.Scripts.Utilities
{
    public static class DevHelper
    {
        private const string NULL_ARGUMENT_MSG = "Required object is null.";

        // Stored in a private member to avoid executing GetComponent everytime
        private static LevelLoader _levelLoader;
        public static LevelLoader LevelLoader
        {
            get
            {
                return _levelLoader ?? (_levelLoader = GetLevelLoader());
            }
        }

        public static T RequireNotNull<T>(T obj)
        {
            return RequireNotNull(obj, NULL_ARGUMENT_MSG);
        }

        public static T RequireNotNull<T>(T obj, string message)
        {
            if (obj == null)
                throw new ArgumentNullException(message);
            return obj;
        }

        // Methods below were made private so programmers only use the properties above!
        private static LevelLoader GetLevelLoader()
        {
            return new LevelLoader();
        }

    }
}