using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTextAppears : MonoBehaviour
{
    [SerializeField] GameObject TexToDisplay;

    //ce serait peut etre mieux avec un raycast jsp

    private void OnTiggerEnter (Collider other)
    {
        Debug.Log(other);

        if (other.CompareTag("Interractable"))
        {
            Debug.Log("interractable");
            TexToDisplay.SetActive(true);
        }

    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Ledge") || other.CompareTag("Interractable"))
        {
            TexToDisplay.SetActive(false);
        }
    }
}
