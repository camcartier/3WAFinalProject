using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] PlayerData PlayerData;
    [SerializeField] GameManager GameManager;

    void Update()
    {
        //why does this work
        //and not the other thing
        if (PlayerData._currentHealth <= 0f)
        {
            Debug.Log("MOURRU");
            GameManager.DeathRespawn();
            PlayerData._currentHealth = PlayerData._maxHealth;
        }


    }
}
