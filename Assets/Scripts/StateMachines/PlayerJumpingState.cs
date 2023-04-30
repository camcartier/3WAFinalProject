using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PlayerJumpingState : PlayerBaseState
{
    private bool _canJump;
    private bool _canJumpTwice;
    private bool _hasJumpedOnce;
    private bool _hasJumpedTwice;

    //public event Action DoubleJumpEvent;

    private readonly int JumpHash = Animator.StringToHash("jump");
    private const float CrossFadeDuration = 0.1f;

    Vector3 movement = new Vector3();

    private Vector3 momentum;

    public PlayerJumpingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {

        stateMachine.ForceReceiver.Jump(stateMachine.JumpForce);


        //momentum = stateMachine.Controller.velocity;
        //momentum.y = 0;

        //Debug.Log(momentum + "number 1 ");

        //stateMachine.Animator.CrossFadeInFixedTime(JumpHash, CrossFadeDuration);

        stateMachine.InputReader.JumpEvent += OnJump;
        stateMachine.InputReader.DashEvent += OnDash;

        stateMachine.LedgeDetector.OnLedgeDetect += HandleLedgeDetect;
    }
    public override void Tick(float deltaTime)
    {
        movement = CalculateMovement();

        Move(movement * stateMachine._movementSpeed, deltaTime);

        //Move(momentum * stateMachine._jumpForwardSpeed, deltaTime);

        if (stateMachine.Controller.velocity.y <=0)
        {
            stateMachine.SwitchState(new PlayerFallingState(stateMachine));
            return;
        }

        FaceTarget();
    }
    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= OnJump;
        stateMachine.InputReader.DashEvent -= OnDash;

        stateMachine.LedgeDetector.OnLedgeDetect -= HandleLedgeDetect;

        //Debug.Log(momentum + "number 2 ");
    }


    /*
    public void OnDoubleJump(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }

        DoubleJumpEvent?.Invoke();
    }*/
    

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerDoubleJumpState(stateMachine));
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
