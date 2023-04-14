using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingState : PlayerBaseState
{
    
    private readonly int TargetingBlendTreeHash = Animator.StringToHash("TargetingBlendTree");


    public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine) { }


    public override void Enter()
    {
        stateMachine.InputReader.CancelEvent += OnCancel;
        stateMachine.InputReader.DashEvent += OnDash;
        stateMachine.InputReader.JumpEvent += OnJump;

        stateMachine.Animator.Play(TargetingBlendTreeHash);
    }
    public override void Tick(float deltaTime)
    {
        if(stateMachine.Targeter.CurrentTarget == null)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            return;
        }

        FaceTarget();


        //Debug.Log(stateMachine.Targeter.CurrentTarget);
    }
    public override void Exit()
    {
        stateMachine.InputReader.CancelEvent -= OnCancel;
        stateMachine.InputReader.DashEvent -= OnDash;
        stateMachine.InputReader.JumpEvent -= OnJump;

    }

    private void OnCancel()
    {

        stateMachine.Targeter.Cancel();

        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }

    private Vector3 CalculateMovement()
    {
        Vector3 movement = new Vector3();



        return movement;
    }


    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerJumpingState(stateMachine));
    }

    private void OnDash() 
    {
        stateMachine.SwitchState(new PlayerDashingState(stateMachine, stateMachine.InputReader.MovementValue ));
    }
}
