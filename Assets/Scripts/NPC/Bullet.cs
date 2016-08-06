using Assets.Scripts.Player.PlayerManagement;
using UnityEngine;

namespace Assets.Scripts.NPC
{
    public class Bullet : MonoBehaviour
    {

        public GameObject target;
        public float projectileSpeed;
        public float damage;

        // Use this for initialization

        public void InitalizeBullet(GameObject target, float projectileSpeed, float damage)
        {
            this.target = target;
            this.projectileSpeed = projectileSpeed;
            this.damage = damage;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position, projectileSpeed * Time.deltaTime);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerInfo player = target.GetComponent<PlayerInfo>();
                

            }
        }
    }
}
