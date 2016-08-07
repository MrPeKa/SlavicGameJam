using UnityEngine;
using System.Collections;
using Assets.Scripts.Sounds;

namespace Assets.Scripts.Gameplay
{
    public class SpawnBossWhenAllMobKilled : MonoBehaviour
    {
        private int _mobCount;
        public GameObject BossModel;
        public GameObject Room;
        private SoundManager _soundsManager;
        public AudioClip SpawnClip;

        void Start()
        {
            StartCoroutine(CheckMobCount());
            _soundsManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        }

        private IEnumerator CheckMobCount()
        {
            while (true)
            {
                _mobCount = gameObject.transform.childCount;
                if (_mobCount < 1)
                {
                    SpawnBoss();
                    yield break;
                }

                yield return new WaitForSeconds(0.2f);
            }
        }

        private void SpawnBoss()
        {
            _soundsManager.NPCEffectsSource.SetClip(SpawnClip);
            _soundsManager.NPCEffectsSource.Play(0.2f, false);
            var boss = Instantiate(BossModel);
            boss.SetPosition(new Vector2(Room.transform.position.x + 2, Room.transform.position.y));
        }
    }
}