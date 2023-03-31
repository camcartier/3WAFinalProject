using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerBaseState
{
    private bool _canJump;
    private bool _canJumpTwice;
    private bool _hasJumpedOnce;
    private bool _hasJumpedTwice;

    private readonly int JumpHash = Animator.StringToHash("jump");
    private const float CrossFadeDuration = 0.1f;
    public PlayerJumpingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.InputReader.JumpEvent += OnJump;
        stateMachine.Animator.CrossFadeInFixedTime(JumpHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        
    }
    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= OnJump;
    }

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerJumpingState(stateMachine));
    }
}
