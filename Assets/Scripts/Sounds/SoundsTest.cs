using UnityEngine;
using System.Collections;

public class SoundsTest : MonoBehaviour {

    private Sounds sounds;

    void Awake()
    {
        sounds = GetComponent<Sounds>();
    }

    public void PlayPlayerHitSound()
    {
        sounds.PlayHitSound(Assets.Scripts.Gameplay.Characters.PLAYER);
    }

    public void PlayPlayerGetHitSound()
    {
        sounds.PlayGetHitSound(Assets.Scripts.Gameplay.Characters.PLAYER);
    }

    public void PlayPlayerDeadSound()
    {
        sounds.PlayDeadSound(Assets.Scripts.Gameplay.Characters.PLAYER);
    }

    public void PlayPlayerFootStepsSound()
    {
        sounds.PlayFootStepsSound(Assets.Scripts.Gameplay.Characters.PLAYER);
    }

    public void PlayPokemonRoomIntroSound()
    {
        sounds.PlayRoomIntroSound(Assets.Scripts.Gameplay.RoomSound.POKEMON);
    }

    public void PlayBayWatchRoomIntroSound()
    {
        sounds.PlayRoomIntroSound(Assets.Scripts.Gameplay.RoomSound.BAY_WATCH);
    }

    public void PlayPowerRangersRoomIntroSound()
    {
        sounds.PlayRoomIntroSound(Assets.Scripts.Gameplay.RoomSound.POWER_RANGERS);
    }

    public void PlayDiscoRoomIntroSoundTest()
    {
        sounds.PlayRoomIntroSound(Assets.Scripts.Gameplay.RoomSound.DISCO);
    }

    public void PlayPokemonPikachuHitSound()
    {
        sounds.PlayHitSound(Assets.Scripts.Gameplay.Characters.PIKACHU);
    }

    public void PlayPokemonPikachuGetHitSound()
    {
        sounds.PlayGetHitSound(Assets.Scripts.Gameplay.Characters.PIKACHU);
    }

    public void PlayPokemonPikachuDeadSound()
    {
        sounds.PlayDeadSound(Assets.Scripts.Gameplay.Characters.PIKACHU);
    }

    public void PlayPokemonPikachuFootStepsSound()
    {
        sounds.PlayFootStepsSound(Assets.Scripts.Gameplay.Characters.PIKACHU);
    }

    public void PlayBayWatchPamelaHitSound()
    {
        sounds.PlayHitSound(Assets.Scripts.Gameplay.Characters.PAMELA);
    }

    public void PlayBayWatchPamelaGetHitSound()
    {
        sounds.PlayGetHitSound(Assets.Scripts.Gameplay.Characters.PAMELA);
    }

    public void PlayBayWatchPamelaDeadSound()
    {
        sounds.PlayDeadSound(Assets.Scripts.Gameplay.Characters.PAMELA);
    }

    public void PlayBayWatchPamelaFootStepsSound()
    {
        sounds.PlayFootStepsSound(Assets.Scripts.Gameplay.Characters.PAMELA);
    }
}
