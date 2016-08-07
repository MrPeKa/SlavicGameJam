using UnityEngine;

namespace Assets.Scripts.NPC
{
    public class NPCWallDetection : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("npc"))
            {
                NPCMovement npcMove = other.gameObject.GetComponent<NPCMovement>();
                if (npcMove != null)
                    npcMove.ChangeDirection();
                else
                    other.gameObject.GetComponent<NPCMovement1>().ChangeDirection();
            }

        }
    }
}