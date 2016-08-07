using UnityEngine;

namespace Assets.Scripts.Sounds
{
    public class SoundsTest : MonoBehaviour
    {

        private Sounds _sounds;

        void Awake()
        {
            _sounds = GetComponent<Sounds>();
        }

        public void PlayPlayerHitSound()
        {
            _sounds.PlayHitSound(Gameplay.Creatures.PLAYER);
        }

        public void PlayPlayerGetHitSound()
        {
            _sounds.PlayGetHitSound(Gameplay.Creatures.PLAYER);
        }

        public void PlayPlayerDeadSound()
        {
            _sounds.PlayDeadSound(Gameplay.Creatures.PLAYER);
        }

        public void PlayPlayerFootStepsSound()
        {
            _sounds.PlayFootStepsSound(Gameplay.Creatures.PLAYER);
        }

        public void PlayNormalBackgroundSound()
        {
            _sounds.PlayRoomIntroSound(Gameplay.RoomSound.NORMAL);
        }

        public void PlayPokemonRoomIntroSound()
        {
            _sounds.PlayRoomIntroSound(Gameplay.RoomSound.POKEMON);
        }

        public void PlayBayWatchRoomIntroSound()
        {
            _sounds.PlayRoomIntroSound(Gameplay.RoomSound.BAY_WATCH);
        }

        public void PlayPowerRangersRoomIntroSound()
        {
            _sounds.PlayRoomIntroSound(Gameplay.RoomSound.POWER_RANGERS);
        }

        public void PlayDiscoRoomIntroSoundTest()
        {
            _sounds.PlayRoomIntroSound(Gameplay.RoomSound.DISCO);
        }

        public void PlayPokemonPikachuHitSound()
        {
            _sounds.PlayHitSound(Gameplay.Creatures.PIKACHU);
        }

        public void PlayPokemonPikachuGetHitSound()
        {
            _sounds.PlayGetHitSound(Gameplay.Creatures.PIKACHU);
        }

        public void PlayPokemonPikachuDeadSound()
        {
            _sounds.PlayDeadSound(Gameplay.Creatures.PIKACHU);
        }

        public void PlayPokemonPikachuFootStepsSound()
        {
            _sounds.PlayFootStepsSound(Gameplay.Creatures.PIKACHU);
        }

        public void PlayBayWatchPamelaHitSound()
        {
            _sounds.PlayHitSound(Gameplay.Creatures.PAMELA);
        }

        public void PlayBayWatchPamelaGetHitSound()
        {
            _sounds.PlayGetHitSound(Gameplay.Creatures.PAMELA);
        }

        public void PlayBayWatchPamelaDeadSound()
        {
            _sounds.PlayDeadSound(Gameplay.Creatures.PAMELA);
        }

        public void PlayBayWatchPamelaFootStepsSound()
        {
            _sounds.PlayFootStepsSound(Gameplay.Creatures.PAMELA);
        }

        public void PlayNormal1HitSound()
        {
            _sounds.PlayHitSound(Gameplay.Creatures.NORMAL1);
        }

        public void PlayNormal1GetHitSound()
        {
            _sounds.PlayGetHitSound(Gameplay.Creatures.NORMAL1);
        }

        public void PlayNormal1DeadSound()
        {
            _sounds.PlayDeadSound(Gameplay.Creatures.NORMAL1);
        }

        public void PlayNormal1FootStepsSound()
        {
            _sounds.PlayFootStepsSound(Gameplay.Creatures.NORMAL1);
        }

        public void PlayMedium1HitSound()
        {
            _sounds.PlayHitSound(Gameplay.Creatures.MEDIUM1);
        }

        public void PlayMedium1GetHitSound()
        {
            _sounds.PlayGetHitSound(Gameplay.Creatures.MEDIUM1);
        }

        public void PlayMedium1DeadSound()
        {
            _sounds.PlayDeadSound(Gameplay.Creatures.MEDIUM1);
        }

        public void PlayMedium1FootStepsSound()
        {
            _sounds.PlayFootStepsSound(Gameplay.Creatures.MEDIUM1);
        }

        public void PlayHard1HitSound()
        {
            _sounds.PlayHitSound(Gameplay.Creatures.HARD1);
        }

        public void PlayHard1GetHitSound()
        {
            _sounds.PlayGetHitSound(Gameplay.Creatures.HARD1);
        }

        public void PlayHard1DeadSound()
        {
            _sounds.PlayDeadSound(Gameplay.Creatures.HARD1);
        }

        public void PlayHard1FootStepsSound()
        {
            _sounds.PlayFootStepsSound(Gameplay.Creatures.HARD1);
        }
    }
}