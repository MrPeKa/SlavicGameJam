using UnityEngine;
using System.Collections;
using Assets.Scripts.Utilities;

namespace Assets.Scripts.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        public const string HORIZONTAL_AXIS_NAME = "Horizontal";
        public const string VERTICAL_AXIS_NAME = "Vertical";
        public const string ATTACK_BUTTON = "Fire1";
        public float playerSpeed;

        private Rigidbody2D rb;
        private float lastXSpeed, lastYSpeed;

        void Start()
        {
            rb = DevHelper.RequireNotNull(GetComponent<Rigidbody2D>());
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

        private void HandleMovement()
        {
            var newXSpeed = GetSpeedForAxis(HORIZONTAL_AXIS_NAME);
            var newYSpeed = GetSpeedForAxis(VERTICAL_AXIS_NAME);
            
            OnMove(newXSpeed, newYSpeed);
        }

        private void OnMove(float newXSpeed, float newYSpeed)
        {
            rb.velocity = new Vector2(newXSpeed, newYSpeed);
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