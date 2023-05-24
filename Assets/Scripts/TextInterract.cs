using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInterract : MonoBehaviour
{
    [SerializeField] GameObject DialoguePanel;

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Interractable"))
        {
            Debug.Log("interractable");
        }
    }


}
