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

    private Vector3 momentum;

    public PlayerJumpingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.JumpEvent += OnJump;

        stateMachine.ForceReceiver.Jump(stateMachine.JumpForce);

        momentum = stateMachine.Controller.velocity;
        momentum.y = 0;

        stateMachine.Animator.CrossFadeInFixedTime(JumpHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        Move(momentum, deltaTime);

        if (stateMachine.Controller.velocity.y <=0)
        {
            stateMachine.SwitchState(new PlayerFallingState(stateMachine));
            return;
        }
        //FaceTarget();
    }
    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= OnJump;
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

}
