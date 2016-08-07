using Assets.Scripts.Gameplay;
using UnityEngine;

namespace Assets.Scripts.Sounds
{
    public static class SoundManager
    {
        public static AudioClip PlayRoomIntroMusic(RoomSound soundComponentName)
        {
            return GetClip(GetClipPath(soundComponentName), GameplayServices.Constants.INTRO);
        }
 
        public static AudioClip PlayDeadSound(Creatures character)
        {
            return GetClip(GetClipPath(character), GameplayServices.Constants.DEAD);
        }
 
        public static AudioClip PlayHitSound(Creatures character)
        {
            return GetClip(GetClipPath(character), GameplayServices.Constants.HIT);
        }

        public static AudioClip PlayGetHitSound(Creatures character)
        {
            return GetClip(GetClipPath(character), GameplayServices.Constants.GET_HIT);
        }

        public static AudioClip PlayFootStepsSound(Creatures character)
        {
            return GetClip(GetClipPath(character), GameplayServices.Constants.FOOTSTEPS);
        }

        private static string GetClipPath(RoomSound soundComponentName)
        {
            string path = null;
            switch (soundComponentName)
            {
                case RoomSound.NORMAL:
                    path = GameplayServices.Constants.SOUNDS_PATH + GameplayServices.Constants.NORMAL;
                    break;

                case RoomSound.POKEMON:
                    path = GameplayServices.Constants.POKEMON_CLIPS_PATH + GameplayServices.Constants.POKEMON;
                    break;

                case RoomSound.BAY_WATCH:
                    path = GameplayServices.Constants.BAY_WATCH_CLIPS_PATH + GameplayServices.Constants.BAY_WATCH;
                    break;

                case RoomSound.POWER_RANGERS:
                    path = GameplayServices.Constants.POWER_RANGERS_CLIPS_PATH + GameplayServices.Constants.POWER_RANGERS;
                    break;

                case RoomSound.DISCO:
                    path = GameplayServices.Constants.DISCO_CLIPS_PATH + GameplayServices.Constants.DISCO;
                    break;

                default:
                    Debug.LogError("Unhandled SoundComponents parameter");
                    break;

            }
            return path;
        }

        private static string GetClipPath(Creatures boss)
        {
            string path = null;
            switch (boss)
            {
                case Creatures.PLAYER:
                    path = GameplayServices.Constants.PLAYER_CLIPS_PATH + GameplayServices.Constants.PLAYER;
                    break;

                case Creatures.PIKACHU:
                    path = GameplayServices.Constants.POKEMON_CLIPS_PATH + GameplayServices.Constants.PIKACHU + "/" + GameplayServices.Constants.PIKACHU;
                    break;

                case Creatures.PAMELA:
                    path = GameplayServices.Constants.BAY_WATCH_CLIPS_PATH + GameplayServices.Constants.PAMELA + "/" + GameplayServices.Constants.PAMELA;
                    break;

                case Creatures.NORMAL1:
                    path = GameplayServices.Constants.STANDARD_CLIPS_PATH + GameplayServices.Constants.NORMAL1 + "/" + GameplayServices.Constants.NORMAL1;
                    break;

                case Creatures.MEDIUM1:
                    path = GameplayServices.Constants.STANDARD_CLIPS_PATH + GameplayServices.Constants.MEDIUM1 + "/" + GameplayServices.Constants.MEDIUM1;
                    break;

                case Creatures.HARD1:
                    path = GameplayServices.Constants.STANDARD_CLIPS_PATH + GameplayServices.Constants.HARD1 + "/" + GameplayServices.Constants.HARD1;
                    break;

                default:
                    Debug.LogError("Unhandled SoundComponents parameter");
                    break;

            }
            return path;
        }

        private static AudioClip GetClip(string clipPath, string clipKind)
        {
            clipPath += clipKind;
            return Resources.Load<AudioClip>(clipPath);
        }
    }
}