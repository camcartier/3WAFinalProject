using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private CharacterController CharacterController;

    // Update is called once per frame
    void Update()
    {
        if (CharacterController.isGrounded)
        {
            Debug.Log("grounded");
        }
    }
}
