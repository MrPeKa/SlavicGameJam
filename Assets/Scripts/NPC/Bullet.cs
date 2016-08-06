using Assets.Scripts.Player.PlayerManagement;
using UnityEngine;

namespace Assets.Scripts.NPC
{
    public class Bullet : MonoBehaviour
    {

        public GameObject target;
        public float projectileSpeed;
        public float damage;
        public Rigidbody2D rb;
        public Animator animator;
        public Vector3 direction;

        // Use this for initialization

        public void InitalizeBullet(GameObject target, float projectileSpeed, float damage)
        {
            this.target = target;
            direction = target.transform.position + new Vector3(0,0.5f,0);
            this.projectileSpeed = projectileSpeed;
            this.damage = damage;
        }

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            rb.AddForce(direction * projectileSpeed);
        }

        // Update is called once per frame
        void Update()
        {
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerInfo player = target.GetComponent<PlayerInfo>();
                player.ApplyDamage(damage);
                animator.SetBool("Splash",true);
                Destroy(gameObject,1);
            }
        }
    }
}