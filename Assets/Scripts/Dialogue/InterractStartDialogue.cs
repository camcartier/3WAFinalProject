using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterractStartDialogue : MonoBehaviour
{
    [SerializeField] GameObject DialoguePanel;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {

        }
    }


    /*
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "player")
        {

        }
    }
    */
}
