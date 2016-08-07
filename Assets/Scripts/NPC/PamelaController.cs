using UnityEngine;
using System.Collections;
using Assets.Scripts.Utilities;

namespace Assets.Scripts.NPC
{
    public class PamelaController : MonoBehaviour
    {
        public const string ANIMATOR_JUMP_TRIGGER_PARAM = "Jump";
        public const string ANIMATOR_HORIZONTAL_AXIS_PARAM = "HorizontalSpeed";
        public const string ANIMATOR_VERTICAL_AXIS_PARAM = "VerticalSpeed";
        public const string ANIMATOR_MOVING_PARAM = "Moving";
        
        private Animator animator;
        private Rigidbody2D rb;

        void Start()
        {
            animator = DevHelper.RequireNotNull(GetComponent<Animator>());
        }


        public void Jump()
        {
            animator.SetTrigger(ANIMATOR_JUMP_TRIGGER_PARAM);
        }

        public void StopJump()
        {
            animator.ResetTrigger(ANIMATOR_JUMP_TRIGGER_PARAM);
        }

        public float HorizontalAxisSpeed
        {
            get
            {
                return animator.GetFloat(ANIMATOR_HORIZONTAL_AXIS_PARAM);
            }
            set
            {
                animator.SetFloat(ANIMATOR_HORIZONTAL_AXIS_PARAM, value);
                if (TryGetRigidBody())
                    rb.velocity = new Vector2(value, rb.velocity.y);
            }
        }

        public float VerticalAxisSpeed
        {
            get
            {
                return animator.GetFloat(ANIMATOR_VERTICAL_AXIS_PARAM);
            }
            set
            {
                animator.SetFloat(ANIMATOR_VERTICAL_AXIS_PARAM, value);
                if (TryGetRigidBody())
                    rb.velocity = new Vector2(rb.velocity.x, value);
            }
        }

        public bool Moving
        {
            get
            {
                return animator.GetBool(ANIMATOR_MOVING_PARAM);
            }
            set
            {
                animator.SetBool(ANIMATOR_MOVING_PARAM, value);
            }
        }


        private bool TryGetRigidBody()
        {
            if (this.rb != null)
                return true;

            var rb = GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                this.rb = rb;
            }

            return this.rb != null;
        }
    }
}