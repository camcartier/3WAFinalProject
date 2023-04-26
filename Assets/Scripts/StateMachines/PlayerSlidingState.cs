using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlidingState : PlayerBaseState
{

    private readonly int SlidingHash = Animator.StringToHash("sliding");
    private const float CrossFadeDuration = 0.1f;

    public PlayerSlidingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Tick(float deltaTime)
    {
        throw new System.NotImplementedException();
    }
}
