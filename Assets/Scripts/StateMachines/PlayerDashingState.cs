using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashingState : PlayerBaseState
{
    private Vector3 momentum;

    private readonly int DashHash = Animator.StringToHash("DashingBlendTree");
    private const float CrossFadeDuration = 0.1f;

    public PlayerDashingState(PlayerStateMachine stateMachine) : base(stateMachine){}

    public override void Enter()
    {
        //stateMachine.ForceReceiver.Dash(stateMachine.DashForce);

        momentum = stateMachine.Controller.velocity;
        momentum.y = 0;

        stateMachine.Animator.CrossFadeInFixedTime(DashHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {

    }

    public override void Exit()
    {

    }


}
