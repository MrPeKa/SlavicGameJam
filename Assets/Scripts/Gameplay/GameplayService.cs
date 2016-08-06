﻿namespace Assets.Scripts.Gameplay
{
    public static class GameplayServices
    {
        public class Tags
        {
            public const string Player = "Player";
        }

        public class Constants
        {
            public const string RoomBackgroundChild = "background";
            public const string StartRoom = "Start Room";
            public const string PlayerName = "player";

            public const string INTRO = "Intro";
            public const string HIT = "Hit";
            public const string GET_HIT = "GetHit";
            public const string DEAD = "Dead";
            public const string FOOTSTEPS = "FootSteps";

            private const string SOUNDS_PATH = "Sounds/";

            public const string PLAYER = "Player";
            public const string POKEMON = "Pokemon";
            public const string BAY_WATCH = "BayWatch";
            public const string POWER_RANGERS = "PowerRangers";
            public const string DISCO = "Disco";

            public const string PLAYER_CLIPS_PATH = SOUNDS_PATH + PLAYER + "/";

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

    public enum Characters
    {
        PLAYER,
        PIKACHU,
        PAMELA
    }
}