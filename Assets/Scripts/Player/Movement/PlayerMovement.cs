using UnityEngine;
using System.Collections;
using Assets.Scripts.Utilities;

namespace Assets.Scripts.Player.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        public const string HORIZONTAL_AXIS_NAME = "Horizontal";
        public const string VERTICAL_AXIS_NAME = "Vertical";
        public const string ATTACK_BUTTON = "Fire1";
        public float playerSpeed;

        private Rigidbody2D rb;
        private float lastXSpeed, lastYSpeed;
        private bool facingRight = true;

        void Start()
        {
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

        private void Flip()
        {
            var localScale = transform.localScale;
            facingRight = !facingRight;
            localScale.x *= -1;
            transform.localScale = localScale;
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

            if ((newXSpeed > 0 && !facingRight) || (newXSpeed < 0 && facingRight))
                Flip();
        }
                

        private void HandleAttack()
        {
            if (Input.GetButtonDown(ATTACK_BUTTON))
                OnAttack();
        }

        private void OnAttack()
        {
            Debug.Log("Attack!");
        }
    }
}