using Assets.Scripts.NPC;
using UnityEngine;

using Assets.Scripts.Player.PlayerManagement;
using System;
using Assets.Scripts.Gameplay;
using Assets.Scripts.Sounds;

namespace Assets.Scripts.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        public const string HORIZONTAL_AXIS_NAME = "Horizontal";
        public const string VERTICAL_AXIS_NAME = "Vertical";
        public const string ATTACK_BUTTON = "Fire1";

        public const string ANIM_PARAM_MOVING = "Moving";
        public const string ANIM_PARAM_ATTACKING = "Attacking";
        public const string ANIM_PARAM_HORIZONTAL_SPEED = "HorizontalSpeed";
        public const string ANIM_PARAM_VERTICAL_SPEED = "VerticalSpeed";
        public const string ANIM_PARAM_LAST_HORIZONTAL_SPEED = "LastHorizontalSpeed";
        public const string ANIM_PARAM_LAST_VERTICAL_SPEED = "LastVerticalSpeed";

        public float playerSpeed;
        public bool isSlowed;
        public PlayerInfo playerInfo;
        public PlayerDetectsOpponents playerDetection;

        private Rigidbody2D rb;
        private Animator animator;
        private float lastXSpeed, lastYSpeed;
        private bool facingRight;
        private bool facingTop;
        private bool moving = false;
        private bool attacking = false;

        private SoundManager _soundsManager;

        bool Moving
        {
            get
            {
                return moving;
            }
            set
            {
                moving = value;
                animator.SetBool(ANIM_PARAM_MOVING, value);
            }
        }

        bool Attacking
        {
            get
            {
                return attacking;
            }
            set
            {
                attacking = value;
                animator.SetBool(ANIM_PARAM_ATTACKING, value);
            }
        }


        void Start()
        {
            playerDetection = GetComponentInChildren<PlayerDetectsOpponents>();
            playerInfo = GetComponent<PlayerInfo>();
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();


            _soundsManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
            _lastAttack = DateTime.Now;
            _attackClip = SoundClipFetcher.HitSound(Creatures.PLAYER);
        }

        void Update()
        {
            HandleMovement();
            HandleAttack();
        }

        private DateTime _lastAttack;
        private AudioClip _attackClip;

        private float GetSpeedForAxis(string axisName)
        {
            return Input.GetAxis(axisName) * playerSpeed;
        }

        private void HandleMovement()
        {
            var newXSpeed = GetSpeedForAxis(HORIZONTAL_AXIS_NAME);
            var newYSpeed = GetSpeedForAxis(VERTICAL_AXIS_NAME);
            
            OnMove(newXSpeed, newYSpeed);
        }

        private void OnMove(float newXSpeed, float newYSpeed)
        {
            var lastVelocity = rb.velocity;

            if (lastVelocity.magnitude != 0)
            {
                animator.SetFloat(ANIM_PARAM_LAST_HORIZONTAL_SPEED, lastVelocity.x);
                animator.SetFloat(ANIM_PARAM_LAST_VERTICAL_SPEED, lastVelocity.y);
            }

            var currentVelocity = new Vector2(newXSpeed, newYSpeed);
            animator.SetFloat(ANIM_PARAM_HORIZONTAL_SPEED, newXSpeed);
            animator.SetFloat(ANIM_PARAM_VERTICAL_SPEED, newYSpeed);

            Moving = (currentVelocity.magnitude != 0);
            rb.velocity = currentVelocity;


        }
                
        private void HandleAttack()
        {
            if (Input.GetButtonDown(ATTACK_BUTTON) && (DateTime.Now - _lastAttack).Seconds >= 1)
            {
                _lastAttack = DateTime.Now;
                OnAttack();
            }
        }

        private void OnAttack()
        {
            StopPlayer();

            if (playerInfo.IsMelee && playerDetection.OpponentInRange)
            {
                foreach (GameObject opponent in playerDetection.ListOfOpponentsInRange)
                {
                    if (playerDetection.ListOfOpponentsInRange.Contains(opponent))
                    {
                        var npcInfo = opponent.GetComponent<NPCInfo>();
                        npcInfo.GetDamage(playerInfo.Damage);
                    }
                }
            }

            _soundsManager.PlayerAttackSource.SetClip(_attackClip);
            _soundsManager.PlayerAttackSource.Play(0.2f, false);

            animator.SetTrigger(ANIM_PARAM_ATTACKING);
        }

        private void StopPlayer()
        {
            rb.velocity = Vector2.zero;
            Moving = false;
        }
    }
}