namespace Assets.Scripts.Gameplay
{
    public static class GameplayServices
    {
        private static IRoomsManager _roomsManager;
        public static IRoomsManager RoomsManager
        {
            get
            {
                return _roomsManager ?? (_roomsManager = GetRoomsManager());
            }
        }

        // Methods below were made private so programmers only use the properties above!
        private static IRoomsManager GetRoomsManager()
        {
            return new RoomsManager();
        }

        public class Tags
        {
            public const string SomeDefaultTag = "TAG";
        }

        public class Constants
        {
            public const string SomeDefaultConstant = "CONSTANT";
        }
    }
}