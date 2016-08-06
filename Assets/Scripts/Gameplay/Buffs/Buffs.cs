using UnityEngine;
using System.Collections;
using Assets.Scripts.Player.Movement;
using Assets.Scripts.Gameplay;
using Assets.Scripts.Player.PlayerManagement;

public class Buffs : MonoBehaviour {

    private GameObject player;
    private PlayerMovement playerMovement;
    private PlayerInfo playerInfo;

    void Awake()
    {
        player = GameObject.Find(GameplayServices.Constants.PlayerName) as GameObject;
        playerMovement = player.GetComponent<PlayerMovement>();
        playerInfo = player.GetComponent<PlayerInfo>();
    }

    // newSpeedPercentage = 0.8 means that the Player will be 20 % slower.
    public void SlowPlayerSpeed(float newSpeedInPercentage, float buffTime)
    {
        if (!playerMovement.isSlowed)
        {
            StartCoroutine(SlowPlayer(newSpeedInPercentage, buffTime));

        }
    }

    // newSpeedPercentage = 1.2 means that the Player will be 20 % heal.
    public void RestorePlayerHealth(float newHealthInPrercentage)
    {
        float healthPointsAfterHeal = playerInfo.HealthPoints * newHealthInPrercentage;
        if (healthPointsAfterHeal <= playerInfo.MaxHealthPoints)
        {
            playerInfo.HealthPoints = healthPointsAfterHeal;
        }
        else
        {
            playerInfo.HealthPoints = playerInfo.MaxHealthPoints;
        }
    }

    private IEnumerator SlowPlayer(float newSpeedInPercentage, float buffTime)
    {
        playerMovement.isSlowed = true;
        float currectPlayerSpeed = playerMovement.playerSpeed;
        playerMovement.playerSpeed *= newSpeedInPercentage;
        yield return new WaitForSeconds(buffTime);
        playerMovement.playerSpeed = currectPlayerSpeed;
        playerMovement.isSlowed = false;
    }
}
