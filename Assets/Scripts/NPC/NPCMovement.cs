using System.Collections;
using System.Diagnostics;
using Assets.Scripts.Gameplay;
using Assets.Scripts.Player.PlayerManagement;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

namespace Assets.Scripts.NPC
{
    public class NPCMovement : MonoBehaviour
    {

        [SerializeField] public float Speed = 0.0005f;
        [SerializeField] public bool FreeTraversing = true;
        [SerializeField] public GameObject TargetToAttack;
        [SerializeField] public bool Targeting;
        [SerializeField] public bool LockPos;
        [SerializeField] public float ProjectileSpeed = 0.3f;
        [SerializeField] public GameObject PrefabOfProjectile;
        [SerializeField] public bool RotatingOnlyInX = false;


        public bool SelfAnimating;

        public NPCInfo npcInfo;

        private Animator anim;

        //Is all about random trversing.
        private int _directionX;
        private int _directionY = 1;
        private bool _isChangingDirection;
        public bool IsFightingMelee;

        //Is all about travelling to the target.
        private float _journeyTime;
        private float _journeyLength;

        //Cooldown related with fighting
        private Stopwatch _cooldownTime;
        public float CoolDownLimitAttact = 2;

        void Awake()
        {
            _cooldownTime = new Stopwatch();
            _cooldownTime.Reset();

            if (SelfAnimating)
            {
                anim = GetComponent<Animator>();
            }

            npcInfo = gameObject.GetComponent<NPCInfo>();
            TargetToAttack = GameObject.FindWithTag("Player");
            StartCoroutine(CheckDirectionCoroutine());
            ResetTarget();
        }


        void Update()
        {
            if (SelfAnimating && !LockPos)
            {
                anim.SetBool("IsMoving", false);
                anim.SetFloat("LastMoveX", _directionX);
                anim.SetFloat("LastMoveY", _directionY);
            }

            if (!_isChangingDirection && !Targeting && !LockPos)
                Move();
            if (!FreeTraversing)
            {
                CheckDirectionInTargeting();
                if(!LockPos)
                    MoveToTheTarget(TargetToAttack);

                    if (_cooldownTime.Elapsed.Milliseconds<=0f)
                    {
                        _cooldownTime.Reset();
                        _cooldownTime.Start();
                        if(IsFightingMelee)
                            AttactMelee(TargetToAttack);
                        else
                            AttactRanged(TargetToAttack);
                    }
                    else if(_cooldownTime.Elapsed.Seconds>=CoolDownLimitAttact)
                        _cooldownTime.Reset();

            }

            if (npcInfo.HealthPoints <= 0)
                Dying();
        }

        //APPLY MUSIC OF DYING
        private void Dying()
        {
            Debug.Log("Object destroyed" + this);
            Destroy(gameObject,1);
        }

        //APPLY MUSIC OF MOVING NPC
        private void Move()
        {
            var newX = transform.position.x + _directionX*Speed;
            var newY = transform.position.y + _directionY*Speed;

            transform.position = new Vector2(newX, newY);

            if (SelfAnimating)
            {
                anim.SetFloat("MoveX", newX);
                anim.SetFloat("MoveY", newY);
                anim.SetBool("IsMoving", true);
            }
        }

        //APPLY MUSIC OF MOVING NPC
        private void MoveToTheTarget(GameObject target)
        {
            if (!Targeting)
            {
                Targeting = true;
                _journeyTime = Time.time;
                _journeyLength = Vector3.Distance(transform.position, target.transform.position);
            }
            else
            {
                float distCovered = (Time.time - _journeyTime)*Speed;
                float fracJourney = distCovered/_journeyLength;
                transform.position = Vector3.LerpUnclamped(transform.position, target.transform.position, fracJourney);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (Targeting && other.CompareTag(GameplayServices.Tags.Player))
            {
                IsFightingMelee = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (Targeting && other.CompareTag(GameplayServices.Tags.Player))
            {
                IsFightingMelee = false;
            }
        }

        //APPLY MUSIC ATTACT OF NPC
        void AttactMelee(GameObject target)
        {
            PlayerInfo player = target.GetComponent<PlayerInfo>();
            player.ApplyDamage(npcInfo.Damage);
        }

        void AttactRanged(GameObject target)
        {
            PlayerInfo player = target.GetComponent<PlayerInfo>();
            FireBullet(target);
        }

        private void FireBullet(GameObject target)
        {
            GameObject projectile = Instantiate(PrefabOfProjectile, this.transform.position, this.transform.rotation) as GameObject;
            if(projectile!=null)
                projectile.GetComponent<Bullet>().InitalizeBullet(target, ProjectileSpeed, npcInfo.Damage);
        }

        private void ResetTarget()
        {
            FreeTraversing = true;
            Targeting = false;
            _journeyTime = 0;
            _journeyLength = 0;
        }

        IEnumerator CheckDirectionCoroutine()
        {
            var time = Random.Range(3, 6);
            while (!Targeting && !LockPos)
            {
                ChangeDirection();
                yield return new WaitForSeconds(time);
            }
        }

        public void ChangeDirection()
        {
            int newDirectX;
            int newDirectY;

            do
            {
                newDirectX = Random.Range(-1, 2);
                newDirectY = Random.Range(-1, 2);
            } while (newDirectY == _directionY || newDirectX == _directionX);

            _directionX = newDirectX;
            _directionY = newDirectY;
            _isChangingDirection = false;

            if (SelfAnimating)
            {
                Move();
                return;
            }
          
            if(_directionY>0)
                FlipUp();
            if(_directionX>0)
                FlipRight();
            if (_directionX < 0)
                FlipLeft();
            if(_directionY<0)
                FlipDown();
        }

        private void CheckDirectionInTargeting()
        {
            var direct = transform.position - TargetToAttack.transform.position;
            bool isXGreaterThanY = Mathf.Abs(direct.x) - Mathf.Abs(direct.y) > 0;
            if (isXGreaterThanY)
            {
                if (direct.x > 0)
                    FlipLeft();
                else
                    FlipRight();
            }
            if (!isXGreaterThanY && !RotatingOnlyInX) { 
                if (direct.y < 0)
                    FlipUp();
                else
                    FlipDown();
            }


        }

        private void FlipRight()
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        private void FlipLeft()
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }

        private void FlipUp()
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }

        private void FlipDown()
        {
            transform.eulerAngles = new Vector3(0, 0, 270);
        }

    }
}
