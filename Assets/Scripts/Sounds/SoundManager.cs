using System.Collections;
using Assets.Scripts.Gameplay;
using UnityEngine;

namespace Assets.Scripts.Sounds
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource RoomMusic;
        public AudioSource CorridorMusic;
        public AudioSource PlayerAttackSource;
        public AudioSource PlayerMoveSource;

        private bool _roomMusicFadeInRequested;
        private bool _roomMusicFadeOutRequested;

        void Start()
        {
            CorridorMusic.SetClip(SoundClipFetcher.GetRoomIntroMusic(RoomSound.NORMAL));
            CorridorMusic.Play(0.1f, true);
        }

        public void FadeInRoomMusic(float volume, float delayInSeconds)
        {
            if (RoomMusic == null)
                return;

            _roomMusicFadeOutRequested = false;
            _roomMusicFadeInRequested = true;
            
            StartCoroutine(FadeIn(RoomMusic, volume, delayInSeconds));
        }

        public void FadeInCorridorMusic(float volume, float delayInSeconds)
        {
            if (RoomMusic == null)
                return;

            StartCoroutine(FadeIn(CorridorMusic, volume, delayInSeconds));
        }

        public void FadeOutRoomMusic(bool stopAudioWhenMuted, float delayInSeconds)
        {
            if (RoomMusic == null)
                return;

            _roomMusicFadeInRequested = false;
            _roomMusicFadeOutRequested = true;

            StartCoroutine(FadeOut(RoomMusic, stopAudioWhenMuted, delayInSeconds));
        }

        public void FadeOutCorridorMusic(bool stopAudioWhenMuted, float delayInSeconds)
        {
            if (RoomMusic == null)
                return;

            StartCoroutine(FadeOut(CorridorMusic, stopAudioWhenMuted, delayInSeconds));
        }

        private IEnumerator FadeIn(AudioSource audioSource, float volume, float delayInSeconds)
        {
            if (audioSource.isPlaying)
                yield break;

            audioSource.Play(0, true);

            var volumeIncrementPerStep = volume/(delayInSeconds*10);

            while (audioSource.volume < volume)
            {
                if (_roomMusicFadeOutRequested)
                {
                    _roomMusicFadeOutRequested = false;
                    yield break;
                }

                audioSource.volume = Mathf.Min(volume, audioSource.volume + volumeIncrementPerStep);
                yield return new WaitForSeconds(0.1f);
            }
        }
        
        private IEnumerator FadeOut(AudioSource audioSource, bool stopAudioWhenMuted, float delayInSeconds)
        {
            if (!audioSource.isPlaying)
                yield break;

            var volumeDecrementPerStep = audioSource.volume / (delayInSeconds * 10);

            while (audioSource.volume > 0)
            {
                if (_roomMusicFadeInRequested)
                {
                    _roomMusicFadeInRequested = false;
                    yield break;
                }

                audioSource.volume = Mathf.Max(0, audioSource.volume - volumeDecrementPerStep);
                yield return new WaitForSeconds(0.1f);
            }

            if (stopAudioWhenMuted)
                audioSource.Stop();
        }
    }

    public static class AudioSourceExtensions
    {
        public static void SetClip(this AudioSource audioSource, AudioClip clip)
        {
            if (audioSource != null)
                audioSource.clip = clip;
        }

        public static void Play(this AudioSource audioSource, float volume, bool loop)
        {
            if (audioSource == null) //|| audioSource.isPlaying)
                return;

            audioSource.loop = loop;
            audioSource.volume = volume;
            audioSource.Play();
        }
    }
}