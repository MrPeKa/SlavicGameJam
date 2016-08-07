using Assets.Scripts.Gameplay;
using UnityEngine;

namespace Assets.Scripts.Sounds
{
    [RequireComponent(typeof(AudioClip))]
    [RequireComponent(typeof(AudioSource))]
    public class Sounds : MonoBehaviour
    {
        [Range(0, 1)]
        public float IntroVolume = 0.1f;

        [Range(0, 1)]
        public float NonIntroVolume = 1f;

        private AudioSource _audioSource;

        void Awake()
        {
            _audioSource = gameObject.GetComponent<AudioSource>();
        }

        private string GetClipPath(RoomSound soundComponentName)
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

        private string GetClipPath(Creatures boss)
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

        private void SetClip(string clipPath, string clipKind)
        {
            if (clipPath != null)
            {
                clipPath += clipKind;
                _audioSource.clip = Resources.Load<AudioClip>(clipPath);
                _audioSource.volume = NonIntroVolume;
                _audioSource.loop = false;
            }
        }

        private void SetClipAndPlay(string clipPath, string clipKind)
        {
            SetClip(clipPath, clipKind);
            StopAndPlayAudioSource();
        }

        public void SetClipIntro(RoomSound soundComponentName)
        {
            SetClip(GetClipPath(soundComponentName), GameplayServices.Constants.INTRO);
            _audioSource.volume = IntroVolume;
            _audioSource.loop = true;
        }

        private void StopAudioSource()
        {
            _audioSource.Stop();
        }

        private void StopAndPlayAudioSource()
        {
            _audioSource.Stop();
            _audioSource.Play();
        }

        public void PlayRoomIntroSound(RoomSound soundComponentName)
        {
            SetClipIntro(soundComponentName);
            StopAndPlayAudioSource();
        }

        public void StopRoomIntroSound(RoomSound soundComponentName)
        {
            SetClipIntro(soundComponentName);
            StopAudioSource();
        }

        public void PlayDeadSound(Creatures character)
        {
            SetClipAndPlay(GetClipPath(character), GameplayServices.Constants.DEAD);
        }

        public void PlayHitSound(Creatures character)
        {
            SetClipAndPlay(GetClipPath(character), GameplayServices.Constants.HIT);
        }

        public void PlayGetHitSound(Creatures character)
        {
            SetClipAndPlay(GetClipPath(character), GameplayServices.Constants.GET_HIT);
        }

        public void PlayFootStepsSound(Creatures character)
        {
            SetClipAndPlay(GetClipPath(character), GameplayServices.Constants.FOOTSTEPS);
        }
    }
}