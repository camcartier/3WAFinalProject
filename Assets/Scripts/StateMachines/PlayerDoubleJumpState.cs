using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJumpState : PlayerBaseState
{

    private Vector3 momentum;

    private readonly int DoubleJumpHash = Animator.StringToHash("doublejump");
    private const float CrossFadeDuration = 0.1f;

    public PlayerDoubleJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("double jump");


        stateMachine.ForceReceiver.DoubleJump(stateMachine.DoubleJumpForce);

        momentum = stateMachine.Controller.velocity;
        momentum.y = 0;

        stateMachine.Animator.CrossFadeInFixedTime(DoubleJumpHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        Move(momentum, deltaTime);

        if (stateMachine.Controller.velocity.y <= 0)
        {
            stateMachine.SwitchState(new PlayerFallingState(stateMachine));
            return;
        }
    }

    public override void Exit()
    {

    }
}
