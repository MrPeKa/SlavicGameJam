﻿using UnityEngine;
using Assets.Scripts.Gameplay;

public class Sounds : MonoBehaviour {

    [Range(0, 1)]
    public float _introVolume = 0.1f;

    [Range(0, 1)]
    public float _nonIntroVolume = 1f;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
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

    private string GetClipPath(Characters boss)
    {
        string path = null;
        switch (boss)
        {
            case Characters.PLAYER:
                path = GameplayServices.Constants.PLAYER_CLIPS_PATH + GameplayServices.Constants.PLAYER;
                break;

            case Characters.PIKACHU:
                path = GameplayServices.Constants.POKEMON_CLIPS_PATH + GameplayServices.Constants.PIKACHU + "/" + GameplayServices.Constants.PIKACHU;
                break;

            case Characters.PAMELA:
                path = GameplayServices.Constants.BAY_WATCH_CLIPS_PATH + GameplayServices.Constants.PAMELA + "/" + GameplayServices.Constants.PAMELA;
                break;

            case Characters.NORMAL1:
                path = GameplayServices.Constants.STANDARD_CLIPS_PATH + GameplayServices.Constants.NORMAL1 + "/" + GameplayServices.Constants.NORMAL1;
                break;

            case Characters.MEDIUM1:
                path = GameplayServices.Constants.STANDARD_CLIPS_PATH + GameplayServices.Constants.MEDIUM1 + "/" + GameplayServices.Constants.MEDIUM1;
                break;

            case Characters.HARD1:
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
            audioSource.clip = Resources.Load<AudioClip>(clipPath);
            audioSource.volume = _nonIntroVolume;
            audioSource.loop = false;
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
        audioSource.volume = _introVolume;
        audioSource.loop = true;
    }

    private void StopAudioSource()
    {
        audioSource.Stop();
    }

    private void StopAndPlayAudioSource()
    {
        audioSource.Stop();
        audioSource.Play();
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

    public void PlayDeadSound(Characters character)
    {
        SetClipAndPlay(GetClipPath(character), GameplayServices.Constants.DEAD);
    }

    public void PlayHitSound(Characters character)
    {
        SetClipAndPlay(GetClipPath(character), GameplayServices.Constants.HIT);
    }

    public void PlayGetHitSound(Characters character)
    {
        SetClipAndPlay(GetClipPath(character), GameplayServices.Constants.GET_HIT);
    }

    public void PlayFootStepsSound(Characters character)
    {
        SetClipAndPlay(GetClipPath(character), GameplayServices.Constants.FOOTSTEPS);
    }

}
