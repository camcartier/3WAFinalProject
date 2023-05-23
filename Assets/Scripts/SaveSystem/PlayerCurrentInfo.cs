using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurrentInfo : MonoBehaviour
{
    [SerializeField] GameManager GameManager;
    [SerializeField] PlayerData PlayerData;

    //name chosen by player;
    public string playerName;

    //player current abilities
    public bool canDoubleJump;
    public bool canDash;
    public bool canUseMagic;

    //scene reached by player;
    public int currentSceneIndex;

    //player current position in the scene;
    public Vector3 playerCurrentPosition;

    void Start()
    {
        
    }

    void Update()
    {
         
    }

}
