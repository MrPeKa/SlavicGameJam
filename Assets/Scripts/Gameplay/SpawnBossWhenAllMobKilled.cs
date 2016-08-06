using UnityEngine;
using System.Collections;
using Assets.Scripts.NPC;

namespace Assets.Scripts.Gameplay
{
    public class SpawnBossWhenAllMobKilled : MonoBehaviour
    {
        private int _mobCount;
        public GameObject BossModel;
        public GameObject Room;

        void Start()
        {
            StartCoroutine(CheckMobCount());
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
            var boss = Instantiate(BossModel);
            boss.SetPosition(new Vector2(Room.transform.position.x, Room.transform.position.y));
        }
    }
}