using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Player.PlayerManagement
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] public float MaxHealthPoints = 100f;
        [SerializeField] public float HealthPoints = 100f;
        [SerializeField] public float Damage = 20f;
        [SerializeField] public bool IsMelee = true;
        public GameObject[] Characters = new GameObject[4];

        public Animator Animator;

        //if null, our player is normal
        private TypeOfCharacter _currentLook;
        private List<TypeOfCharacter> ListOflooks;

        void Awake()
        {
            ListOflooks = new List<TypeOfCharacter>();
            Animator = gameObject.GetComponent<Animator>();
//            foreach (var character in Characters)    
//            {
//                ListOflooks.Add(character.GetComponent<TypeOfCharacter>());
//            }
        }

        void Update()
        {
        }

        public void GetDamage(float value)
        {
            HealthPoints -= value;
        }

        public void GetHP(float value)
        {
            HealthPoints += value;
        }

        public void ChangeHealth(float value)
        {
            HealthPoints = value;
        }

        public void ChangeDamage(float value)
        {
            Damage = value;
        }

        public void ChangeCharacter(TypeOfCharacter type)
        {
            _currentLook = type;
            Animator.runtimeAnimatorController = type.AnimatorOverride;
            if (type.IsMelee)
                IsMelee = true;
            else
                IsMelee = false;
                Damage = type.Damage;
            }
        }

    }

