using System.Collections;
using UnityEngine;

namespace Assets.Scripts.NPC
{
    public class NPCMovement : MonoBehaviour
    {

        [SerializeField] public float Speed = 0.0005f;
        [SerializeField] public bool FreeTraversing = true;
        [SerializeField] public GameObject TargetToAttack;
        [SerializeField] public bool Targeting;

        //Is all about random trversing.
        private int _directionX;
        private int _directionY = 1;
        private bool _isChangingDirection;

        //Is all about travelling to the target.
        private float _journeyTime;
        private float _journeyLength;

        void Awake()
        {
            TargetToAttack = GameObject.FindWithTag("target");
            StartCoroutine(CheckDirection());
            ResetTarget();
        }

        void Update()
        {
            if(!_isChangingDirection && !Targeting)
                Move();
            if(!FreeTraversing)
                MoveToTheTarget(TargetToAttack);
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
            if (Targeting && other.CompareTag("target"))
            {
                ResetTarget();
                Debug.Log("achieved");
            }
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

        public Vector2 ChangeDirection()
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

            return new Vector2(_directionX,_directionY);
        }

    }
}
