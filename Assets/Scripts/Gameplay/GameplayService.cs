namespace Assets.Scripts.Gameplay
{
    public static class GameplayServices
    {
        public class Tags
        {
            public const string Player = "Player";
        }

        public class Constants
        {
            // For each string define enum
            public const string PLAYER = "Player";
            public const string PIKACHU = "Pikachu";
            public const string PAMELA = "Pamela";
            public const string NORMAL1 = "Normal1";
            public const string MEDIUM1 = "Medium1";
            public const string HARD1 = "Hard1";
            // End

            public const string RoomBackgroundChild = "background";
            public const string StartRoom = "Start Room";
            public const string PlayerName = "Player";

            // Sound Extentions
            public const string INTRO = "Intro";
            public const string HIT = "Hit";
            public const string GET_HIT = "GetHit";
            public const string DEAD = "Dead";
            public const string FOOTSTEPS = "FootSteps";
            // End

            public const string SOUNDS_PATH = "Sounds/";

            public const string NORMAL = "NormalBackground";

            public const string POKEMON = "Pokemon";
            public const string BAY_WATCH = "BayWatch";
            public const string POWER_RANGERS = "PowerRangers";
            public const string DISCO = "Disco";
            public const string STANDARD = "Standard";

            

            // Player
            public const string PLAYER_CLIPS_PATH = SOUNDS_PATH + PLAYER + "/";

            // Bosses
            public const string POKEMON_CLIPS_PATH = SOUNDS_PATH + POKEMON + "/";
            public const string BAY_WATCH_CLIPS_PATH = SOUNDS_PATH + BAY_WATCH + "/";
            public const string POWER_RANGERS_CLIPS_PATH = SOUNDS_PATH + POWER_RANGERS + "/";
            public const string DISCO_CLIPS_PATH = SOUNDS_PATH + DISCO + "/";

            // Standard
            public const string STANDARD_CLIPS_PATH = SOUNDS_PATH + STANDARD + "/";


        }
    }

    public enum RoomSound
    {
        NORMAL, // Normal background sound
        POKEMON,
        BAY_WATCH,
        POWER_RANGERS,
        DISCO
    }

    // For each enum define string
    public enum Creatures
    {
        PLAYER,
        PIKACHU,
        PAMELA,
        NORMAL1,
        MEDIUM1,
        HARD1
    }
}