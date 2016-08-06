using UnityEngine;
using System.Collections;
using Assets.Scripts.Gameplay;

public class LifeTree : MonoBehaviour {

    public float healthPointsAfterUseInPercentage = 1.2f;
    public bool alreadyUsed = false;

    Buffs buffs;

    void Awake()
    {
        buffs = GameObject.Find(GameplayServices.Constants.BUFFS_MANAGER).GetComponent<Buffs>();   
    }

    void OnMouseDown()
    {
        if (!alreadyUsed)
        {
            alreadyUsed = true;
            buffs.RestorePlayerHealth(healthPointsAfterUseInPercentage);
        }
        
    }
}
