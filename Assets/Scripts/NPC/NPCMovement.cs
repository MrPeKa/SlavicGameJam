using System.Collections;
using System.Diagnostics;
using Assets.Scripts.Gameplay;
using Assets.Scripts.Player.PlayerManagement;
using Assets.Scripts.Sounds;
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
        [SerializeField] public bool OnlyMirrorRotating = false;
        [SerializeField] public bool StopBeforeShoot = false;


        public bool SelfAnimating;

        public NPCInfo npcInfo;

        private Animator anim;

        //Is all about random trversing.
        private int _directionX;
        private int _directionY = 1;
        private bool _isChangingDirection;
        private Rigidbody2D rigidbody;
        private Vector2 currentDirrection;
        private float last_x;
        private float last_y;
        public bool IsFightingMelee;

        //Is all about travelling to the target.
        private float _journeyTime;
        private float _journeyLength;

        //Cooldown related with fighting
        private Stopwatch _cooldownTime;
        public float CoolDownLimitAttact = 2;

        private SoundManager _soundsManager;
        public bool hasIdle = true;

        void Awake()
        {
            _cooldownTime = new Stopwatch();
            _cooldownTime.Reset();

            if (SelfAnimating)
            {
                anim = GetComponent<Animator>();
                rigidbody = GetComponent<Rigidbody2D>();
            }

            npcInfo = gameObject.GetComponent<NPCInfo>();
            TargetToAttack = GameObject.FindWithTag("Player");
            StartCoroutine(CheckDirectionCoroutine());
            ResetTarget();
        }

        void Start()
        {
            _soundsManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        }

        void Update()
        { 
            last_x = transform.position.x;
            last_y = transform.position.y;

            if (SelfAnimating && !LockPos && hasIdle)
            {
                if ((Mathf.Abs(transform.position.x) - Mathf.Abs(last_x) == 0)
                    && (Mathf.Abs(transform.position.y) - Mathf.Abs(last_y)) == 0)
                {
                    anim.SetBool("IsMoving", false);
                    anim.SetFloat("LastMoveX", currentDirrection.x);
                    anim.SetFloat("LastMoveY", currentDirrection.y);
                }
            }

            if (!_isChangingDirection && !Targeting && !LockPos)
                Move();
            if (!FreeTraversing)
            {
                CheckDirectionInTargeting();
                if(!LockPos)
                    MoveToTheTarget(TargetToAttack);

                if (_cooldownTime.Elapsed.Milliseconds <= 0f)
                {
                    _cooldownTime.Reset();
                    _cooldownTime.Start();
                    if (IsFightingMelee)
                    {
                        AttactMelee(TargetToAttack);
                    }
                    else
                    {
                        if (StopBeforeShoot)
                        {
                            LockPos = true;
                        }
                        AttactRanged(TargetToAttack);
                        if (StopBeforeShoot)
                        {
                            LockPos = false;
                        }
                    }
                }
                else if (_cooldownTime.Elapsed.Seconds >= CoolDownLimitAttact)
                    _cooldownTime.Reset();

            }

            if (npcInfo.HealthPoints <= 0)
                Dying();
        }

        //APPLY MUSIC OF DYING
        private void Dying()
        {
            Debug.Log("Object destroyed" + this);
            var deadBody = Instantiate(Resources.Load("Dead"), this.transform.position, this.transform.rotation);
            DestroyObject(deadBody,0.5f);
            Destroy(gameObject,0.2f);
        }

        //APPLY MUSIC OF MOVING NPC
        private void Move()
        {
            var newX = transform.position.x + _directionX*Speed;
            var newY = transform.position.y + _directionY*Speed;

            transform.position = new Vector2(newX, newY);

            if (SelfAnimating && !OnlyMirrorRotating)
            {
                SetCurrentDirection(newX, newY);

                anim.SetBool("IsMoving", true);
                anim.SetFloat("MoveX", currentDirrection.x);
                anim.SetFloat("MoveY", currentDirrection.y);
            }
        }

        private void SetCurrentDirection(float newX, float newY)
        {
                if (newX > last_x)
                {
                    currentDirrection.x = 1;
                }
                else if (newX < last_x)
                {
                    currentDirrection.x = -1;
                }
                else
                {
                    currentDirrection.x = 0;
                }

                if (newY < last_y)
                {
                    currentDirrection.y = -1;
                }
                else if (newY > last_y)
                {
                    currentDirrection.y = 1;
                }
                else
                {
                    currentDirrection.y = 0;
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

            if (SelfAnimating || OnlyMirrorRotating)
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
            if (!OnlyMirrorRotating)
            {
                if (Mathf.Abs(direct.x) - Mathf.Abs(direct.y) > 0)
                {
                    if (direct.x > 0)
                        FlipLeft();
                    else
                        FlipRight();
                }
                else if (direct.y < 0)
                    FlipUp();
                else
                    FlipDown();
            }
            else
            {
                if(direct.x < 0)
                {
                    FlipRightMirror();
                }
                else if (direct.x > 0)
                {
                    FlipLeftMirror();
                }
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

        private void FlipLeftMirror()
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        private void FlipRightMirror()
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

    }
}
