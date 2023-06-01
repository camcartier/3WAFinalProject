using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawn : MonoBehaviour
{
    [SerializeField] CharacterController CharacterController;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject RespawnPoint;
    [SerializeField] PlayerData PlayerData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("fell");
            CharacterController.enabled= false;
            Vector3 RespawnPos = new Vector3(RespawnPoint.transform.position.x, RespawnPoint.transform.position.y, RespawnPoint.transform.position.z);

            Player.transform.position = RespawnPos;

            CharacterController.enabled = true;

            PlayerData._currentHealth = PlayerData._maxHealth;
        }
    }
}
