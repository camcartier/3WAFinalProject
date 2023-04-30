using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerBaseState
{

    private readonly int FallHash = Animator.StringToHash("fall");
    private const float CrossFadeDuration = 0.1f;

    Vector3 movement = new Vector3();

    private Vector3 momentum;

    public PlayerFallingState(PlayerStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {

        Debug.Log("falling");

        //momentum = stateMachine.Controller.velocity;
        //momentum.y = 0;

        stateMachine.InputReader.DashEvent += OnDash;
        stateMachine.LedgeDetector.OnLedgeDetect += HandleLedgeDetect;

        stateMachine.Animator.CrossFadeInFixedTime(FallHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {

        movement = CalculateMovement();

        Move(movement * stateMachine._movementSpeed, deltaTime);

        //Move(momentum, deltaTime);

        if (stateMachine.Controller.isGrounded )
        {
            Debug.Log("grounded");


            ReturnToLocomotion();
        }

        //FaceTarget();
    }

    public override void Exit()
    {
        stateMachine.InputReader.DashEvent -= OnDash;
        stateMachine.LedgeDetector.OnLedgeDetect -= HandleLedgeDetect;

    }

    private void OnFall()
    {

    }

    private void OnDash()
    {
        stateMachine.SwitchState(new PlayerDashingState(stateMachine));
    }


    private void HandleLedgeDetect(Vector3 closestPoint, Vector3 ledgeForward)
    {
        stateMachine.SwitchState(new PlayerHangingState(stateMachine, closestPoint, ledgeForward));
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
