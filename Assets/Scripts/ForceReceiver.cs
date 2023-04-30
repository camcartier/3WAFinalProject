using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceReceiver : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    private float verticalVelocity;
    private float horizontalVelocity;   

    public Vector3 Movement => Vector3.up * verticalVelocity;

    public Vector3 DashMove => new Vector3(1, 0, 1) * horizontalVelocity;

    private void Update()
    {
        if (verticalVelocity < 0f && controller.isGrounded)
        {
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
    }

    public void Jump(float jumpForce)
    {
        verticalVelocity += jumpForce;    
    }


    public void DoubleJump(float doubleJumpForce)
    {
        verticalVelocity += doubleJumpForce;
    }

    public void Reset()
    {
        // impact = Vector3.zero;
        verticalVelocity = 0f;  

    }

    /*
    public void Dash(float dashForce)
    {
        horizontalVelocity += dashForce;
    }*/
}
