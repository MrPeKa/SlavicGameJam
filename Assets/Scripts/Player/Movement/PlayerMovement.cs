using Assets.Scripts.NPC;
using UnityEngine;

using Assets.Scripts.Player.PlayerManagement;


namespace Assets.Scripts.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        public const string HORIZONTAL_AXIS_NAME = "Horizontal";
        public const string VERTICAL_AXIS_NAME = "Vertical";
        public const string ATTACK_BUTTON = "Fire1";
        public float playerSpeed;

        public PlayerInfo playerInfo;
        public PlayerDetectsOpponents playerDetection;

        private Rigidbody2D rb;
        private float lastXSpeed, lastYSpeed;
        private bool facingRight = true;
        private bool facingTop = false;

        void Start()
        {
            playerDetection = GetComponentInChildren<PlayerDetectsOpponents>();
            playerInfo = GetComponent<PlayerInfo>();
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            HandleMovement();
            HandleAttack();
        }


        private float GetSpeedForAxis(string axisName)
        {
            return Input.GetAxis(axisName) * playerSpeed;
        }

        private void FlipRight()
        {
            facingTop = false;
            facingRight = true;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        private void FlipLeft()
        {
            facingTop = true;
            facingRight = false;
            transform.eulerAngles = new Vector3(0, 0, 180);
        }

        private void FlipUp()
        {
            facingTop = true;
            facingRight = true;
            transform.eulerAngles = new Vector3(0, 0, 90);
        }

        private void FlipDown()
        {
            facingTop = false;
            facingRight = false;
            transform.eulerAngles = new Vector3(0, 0, 270);
        }

        private void HandleMovement()
        {
            var newXSpeed = GetSpeedForAxis(HORIZONTAL_AXIS_NAME);
            var newYSpeed = GetSpeedForAxis(VERTICAL_AXIS_NAME);
            
            OnMove(newXSpeed, newYSpeed);
        }

        private void OnMove(float newXSpeed, float newYSpeed)
        {
            rb.velocity = new Vector2(newXSpeed, newYSpeed);

            if(newYSpeed>0)
                FlipUp();
            if(newYSpeed<0)
                FlipDown();
            if(newXSpeed>0)
                FlipRight();
            if(newXSpeed<0)
                FlipLeft();
        }
                
        private void HandleAttack()
        {
            if (Input.GetButtonDown(ATTACK_BUTTON))
                OnAttack();
        }

        private void OnAttack()
        {
            if (playerInfo.IsMelee && playerDetection.OpponentInRange)
            {
                foreach (GameObject opponent in playerDetection.ListOfOpponentsInRange)
                {
                    var npcInfo = opponent.GetComponent<NPCInfo>();
                    npcInfo.GetDamage(playerInfo.Damage);
                }
            }
        }
    }
}