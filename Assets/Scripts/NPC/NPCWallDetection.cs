using Assets.Scripts.NPC;
using UnityEngine;

public class NPCWallDetection : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("npc"))
        {
            other.gameObject.GetComponent<NPCMovement>().ChangeDirection();
        }
    }

}
