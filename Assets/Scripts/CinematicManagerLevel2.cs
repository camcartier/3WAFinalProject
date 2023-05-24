using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicManagerLevel2 : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject playerPlaceHolder;

    public void EnablePlayer()
    {
        player.SetActive(true);
        playerPlaceHolder.SetActive(false);
    }

}
