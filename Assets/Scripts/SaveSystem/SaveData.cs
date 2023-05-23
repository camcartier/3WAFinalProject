using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveData 
{

    public string playerName;

    public bool canDoubleJump;
    public bool canDash;
    public bool canUseMagic;

    public int sceneIndex;

    public float[] position;


    public SaveData (PlayerCurrentInfo playerCurrentInfo)
    {
        playerName= playerCurrentInfo.playerName;
        sceneIndex= playerCurrentInfo.currentSceneIndex;


        position= new float[3];
        position[0]= playerCurrentInfo.transform.position.x;
        position[1]= playerCurrentInfo.transform.position.y;
        position[2]= playerCurrentInfo.transform.position.z;

    }

}
