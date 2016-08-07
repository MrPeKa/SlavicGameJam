using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.NPC
{
    public class DetectAngle : MonoBehaviour
    {

        public bool GoAttact;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GoAttact = true;
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GoAttact = false;
            }
        }

    }
}
