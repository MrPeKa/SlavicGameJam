using UnityEngine;
using System.Collections;
using Assets.Scripts.Gameplay;

public class EnterToWater : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(GameplayServices.Tags.Player))
        {
            Debug.Log("orka!");
            var orca = Instantiate(Resources.Load("orca") as GameObject, new Vector3(-5.81f, -5.74f, 0f),
                transform.rotation);
            DestroyObject(orca,3);
        }
    }
}
