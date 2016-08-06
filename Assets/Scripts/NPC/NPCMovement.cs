using System.Collections;
using System.Diagnostics;
using Assets.Scripts.Gameplay;
using Assets.Scripts.Player.PlayerManagement;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.NPC
{
    public class NPCMovement : MonoBehaviour
    {

        [SerializeField] public float Speed = 0.0005f;
        [SerializeField] public bool FreeTraversing = true;
        [SerializeField] public GameObject TargetToAttack;
        [SerializeField] public bool Targeting;

        public bool SelfAnimating;

        public NPCInfo npcInfo;

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
            npcInfo = gameObject.GetComponent<NPCInfo>();
            TargetToAttack = GameObject.FindWithTag("Player");
            StartCoroutine(CheckDirection());
            ResetTarget();
        }


        void Update()
        {
            if(!_isChangingDirection && !Targeting)
                Move();
            if (!FreeTraversing)
            {
                MoveToTheTarget(TargetToAttack);
                if (IsFightingMelee)
                {
                    if (_cooldownTime.Elapsed.Milliseconds<=0f)
                    {
                        _cooldownTime.Reset();
                        _cooldownTime.Start();
                        AttactMelee(TargetToAttack);
                    }
                    else if(_cooldownTime.Elapsed.Seconds>=CoolDownLimitAttact)
                        _cooldownTime.Reset();
                }
            }
        }

        private void Move()
        {
            var newX = transform.position.x + _directionX*Speed;
            var newY = transform.position.y + _directionY*Speed;
            transform.position = new Vector2(newX, newY);
        }

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

        void AttactMelee(GameObject target)
        {
            PlayerInfo player = target.GetComponent<PlayerInfo>();
            player.GetDamage(npcInfo.Damage);
        }

        private void ResetTarget()
        {
            FreeTraversing = true;
            Targeting = false;
            _journeyTime = 0;
            _journeyLength = 0;
        }

        IEnumerator CheckDirection()
        {
            var time = Random.Range(3, 6);
            while (!Targeting)
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
