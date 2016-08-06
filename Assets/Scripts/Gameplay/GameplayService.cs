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

            public const string INTRO = "Intro";
            public const string HIT = "Hit";
            public const string GET_HIT = "GetHit";
            public const string DEAD = "Dead";
            public const string FOOTSTEPS = "FootSteps";


            private const string SOUNDS_PATH = "Sounds/";

            public const string POKEMON = "Pokemon";
            public const string BAY_WATCH = "BayWatch";
            public const string POWER_RANGERS = "PowerRangers";
            public const string DISCO = "Disco";

            public const string POKEMON_CLIPS_PATH = SOUNDS_PATH + POKEMON + "/";
            public const string BAY_WATCH_CLIPS_PATH = SOUNDS_PATH + BAY_WATCH + "/";
            public const string POWER_RANGERS_CLIPS_PATH = SOUNDS_PATH + POWER_RANGERS + "/";
            public const string DISCO_CLIPS_PATH = SOUNDS_PATH + DISCO + "/";

            public const string PIKACHU = "Pikachu";
            public const string PAMELA = "Pamela";
        }

        
    }

    public enum RoomSound
    {
        POKEMON,
        BAY_WATCH,
        POWER_RANGERS,
        DISCO
    }

    public enum Bosses
    {
        PIKACHU,
        PAMELA
    }
}