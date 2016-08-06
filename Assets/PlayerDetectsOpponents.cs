using UnityEngine;
using System.Collections.Generic;

public class PlayerDetectsOpponents : MonoBehaviour {

    public bool OpponentInRange;
    public List<GameObject> listOfOpponentsInRange;
    private int _counter;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("npc")) { 
            listOfOpponentsInRange.Add(other.gameObject);
        OpponentInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("npc"))
        {
            if (listOfOpponentsInRange.Contains(other.gameObject))
                listOfOpponentsInRange.Remove(other.gameObject);
            OpponentInRange = false;
        }
    }

}
