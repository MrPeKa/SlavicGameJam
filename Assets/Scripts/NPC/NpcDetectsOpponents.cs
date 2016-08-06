using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.NPC
{
    public class NpcDetectsOpponents : MonoBehaviour {

        public bool OpponentInRange;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) { 
                OpponentInRange = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                OpponentInRange = false;
            }
        }

    }
}
