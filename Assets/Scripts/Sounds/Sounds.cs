using UnityEngine;
using Assets.Scripts.Gameplay;

public class Sounds : MonoBehaviour {

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

    private string GetClipPath(Bosses boss)
    {
        string path = null;
        switch (boss)
        {
            case Bosses.PIKACHU:
                path = GameplayServices.Constants.POKEMON_CLIPS_PATH + GameplayServices.Constants.PIKACHU + "/" + GameplayServices.Constants.PIKACHU;
                break;

            case Bosses.PAMELA:
                path = GameplayServices.Constants.BAY_WATCH_CLIPS_PATH + GameplayServices.Constants.PAMELA + "/" + GameplayServices.Constants.PAMELA;
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

    public void PlayDeadSound(Bosses boss)
    {
        SetClipAndPlay(GetClipPath(boss), GameplayServices.Constants.DEAD);
    }

    public void PlayHitSound(Bosses boss)
    {
        SetClipAndPlay(GetClipPath(boss), GameplayServices.Constants.HIT);
    }

    public void PlayGetHitSound(Bosses boss)
    {
        SetClipAndPlay(GetClipPath(boss), GameplayServices.Constants.GET_HIT);
    }

    public void PlayFootStepsSound(Bosses boss)
    {
        SetClipAndPlay(GetClipPath(boss), GameplayServices.Constants.FOOTSTEPS);
    }

}
