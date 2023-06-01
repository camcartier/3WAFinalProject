using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashingState : PlayerBaseState
{
    private Vector3 momentum;
    //private float _timer = 0.5f;
    //private float _timerCounter = 0f;

    private readonly int DashBlendTreeHash = Animator.StringToHash("DashingBlendTree");

    private readonly int DashForwardHash = Animator.StringToHash("DashingForward");

    private readonly int DashRightHash = Animator.StringToHash("DashingRight");

    //private Vector2 DashingDirectionInput;
    //private float RemainingDashTime;

    private const float CrossFadeDuration = 0.1f;

    private Vector3 dashingDirectionInput;

    private float remainingDashTime;

    /*
    public PlayerDashingState(PlayerStateMachine stateMachine, Vector3 dashingDirectionInput) : base(stateMachine)
    {

        this.dashingDirectionInput = dashingDirectionInput;
    }*/


    public PlayerDashingState(PlayerStateMachine stateMachine) : base(stateMachine)
    { 
    }


    public override void Enter()
    {
        //Debug.Log("dash");


        //DashingDirectionInput = stateMachine.InputReader.MovementValue;
        //RemainingDashTime = stateMachine.DashDuration;
        //momentum = stateMachine.Controller.velocity;
        //momentum.y = 0;

        stateMachine.GameManager._isDashing = true;

        remainingDashTime = stateMachine.DashDuration;

        stateMachine.Animator.CrossFadeInFixedTime(DashBlendTreeHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {

        //Vector3 movement = new Vector3();

        Vector3 movement = CalculateMovement();

        //movement += stateMachine.transform.right * dashingDirectionInput.x * stateMachine.DashDistance / stateMachine.DashDuration;
        //movement += stateMachine.transform.forward * dashingDirectionInput.y * stateMachine.DashDistance / stateMachine.DashDuration;

        //movement += stateMachine.transform.right * stateMachine.DashDistance / stateMachine.DashDuration;
        
        //cc working
        movement += stateMachine.transform.forward * stateMachine.DashDistance / stateMachine.DashDuration;
        //cc working
        Move(movement, deltaTime);

        remainingDashTime -= deltaTime;

        if (remainingDashTime <= 0)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));

        }




        //dash Sammy
        /*
        Vector3 movement = new Vector3();
        movement += stateMachine.MainCameraTransform.right * dashingDirectionInput.x;
        movement += stateMachine.MainCameraTransform.forward * dashingDirectionInput.y;
        Move(movement * (stateMachine.DashDistance / stateMachine.DashDistance), deltaTime);
        */

    }

    public override void Exit()
    {
        stateMachine.GameManager._isDashing = false;
    }

    private Vector3 CalculateMovement()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0; right.y = 0;

        forward.Normalize(); right.Normalize();

        return forward * stateMachine.InputReader.MovementValue.y + right * stateMachine.InputReader.MovementValue.x;
    }

    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation,
            Quaternion.LookRotation(movement),
            deltaTime * stateMachine.RotationDamping);
    }

}
