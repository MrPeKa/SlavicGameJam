using UnityEngine;

namespace Assets.Scripts.NPC
{
    public class NPCInfo : MonoBehaviour {

        [SerializeField]
        public float HealthPoints = 100f;
        [SerializeField]
        public float Damage = 20f;
        [SerializeField]
        public bool IsMelee = true;

        // Use this for initialization
        void Start () {
	
        }
	
        // Update is called once per frame
        void Update () {
	
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

    }
}
