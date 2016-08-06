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
        sounds.PlayHitSound(Assets.Scripts.Gameplay.Creatures.PLAYER);
    }

    public void PlayPlayerGetHitSound()
    {
        sounds.PlayGetHitSound(Assets.Scripts.Gameplay.Creatures.PLAYER);
    }

    public void PlayPlayerDeadSound()
    {
        sounds.PlayDeadSound(Assets.Scripts.Gameplay.Creatures.PLAYER);
    }

    public void PlayPlayerFootStepsSound()
    {
        sounds.PlayFootStepsSound(Assets.Scripts.Gameplay.Creatures.PLAYER);
    }

    public void PlayNormalBackgroundSound()
    {
        sounds.PlayRoomIntroSound(Assets.Scripts.Gameplay.RoomSound.NORMAL);
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
        sounds.PlayHitSound(Assets.Scripts.Gameplay.Creatures.PIKACHU);
    }

    public void PlayPokemonPikachuGetHitSound()
    {
        sounds.PlayGetHitSound(Assets.Scripts.Gameplay.Creatures.PIKACHU);
    }

    public void PlayPokemonPikachuDeadSound()
    {
        sounds.PlayDeadSound(Assets.Scripts.Gameplay.Creatures.PIKACHU);
    }

    public void PlayPokemonPikachuFootStepsSound()
    {
        sounds.PlayFootStepsSound(Assets.Scripts.Gameplay.Creatures.PIKACHU);
    }

    public void PlayBayWatchPamelaHitSound()
    {
        sounds.PlayHitSound(Assets.Scripts.Gameplay.Creatures.PAMELA);
    }

    public void PlayBayWatchPamelaGetHitSound()
    {
        sounds.PlayGetHitSound(Assets.Scripts.Gameplay.Creatures.PAMELA);
    }

    public void PlayBayWatchPamelaDeadSound()
    {
        sounds.PlayDeadSound(Assets.Scripts.Gameplay.Creatures.PAMELA);
    }

    public void PlayBayWatchPamelaFootStepsSound()
    {
        sounds.PlayFootStepsSound(Assets.Scripts.Gameplay.Creatures.PAMELA);
    }

    public void PlayNormal1HitSound()
    {
        sounds.PlayHitSound(Assets.Scripts.Gameplay.Creatures.NORMAL1);
    }

    public void PlayNormal1GetHitSound()
    {
        sounds.PlayGetHitSound(Assets.Scripts.Gameplay.Creatures.NORMAL1);
    }

    public void PlayNormal1DeadSound()
    {
        sounds.PlayDeadSound(Assets.Scripts.Gameplay.Creatures.NORMAL1);
    }

    public void PlayNormal1FootStepsSound()
    {
        sounds.PlayFootStepsSound(Assets.Scripts.Gameplay.Creatures.NORMAL1);
    }

    public void PlayMedium1HitSound()
    {
        sounds.PlayHitSound(Assets.Scripts.Gameplay.Creatures.MEDIUM1);
    }

    public void PlayMedium1GetHitSound()
    {
        sounds.PlayGetHitSound(Assets.Scripts.Gameplay.Creatures.MEDIUM1);
    }

    public void PlayMedium1DeadSound()
    {
        sounds.PlayDeadSound(Assets.Scripts.Gameplay.Creatures.MEDIUM1);
    }

    public void PlayMedium1FootStepsSound()
    {
        sounds.PlayFootStepsSound(Assets.Scripts.Gameplay.Creatures.MEDIUM1);
    }

    public void PlayHard1HitSound()
    {
        sounds.PlayHitSound(Assets.Scripts.Gameplay.Creatures.HARD1);
    }

    public void PlayHard1GetHitSound()
    {
        sounds.PlayGetHitSound(Assets.Scripts.Gameplay.Creatures.HARD1);
    }

    public void PlayHard1DeadSound()
    {
        sounds.PlayDeadSound(Assets.Scripts.Gameplay.Creatures.HARD1);
    }

    public void PlayHard1FootStepsSound()
    {
        sounds.PlayFootStepsSound(Assets.Scripts.Gameplay.Creatures.HARD1);
    }
}
