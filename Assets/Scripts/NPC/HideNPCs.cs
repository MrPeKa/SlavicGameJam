using UnityEngine;

namespace Assets.Scripts.NPC
{
    public class HideNPCs : MonoBehaviour
    {
        public void Hide()
        {
            foreach (Transform npc in gameObject.transform)
            {
                npc.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        public void Show()
        {
            foreach (Transform npc in gameObject.transform)
            {
                npc.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
}