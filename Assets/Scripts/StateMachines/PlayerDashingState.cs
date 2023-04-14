using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashingState : PlayerBaseState
{
    private Vector3 momentum;
    private float _timer = 0.5f;
    private float _timerCounter = 0f;

    private readonly int DashBlendTreeHash = Animator.StringToHash("DashingBlendTree");

    private readonly int DashForwardHash = Animator.StringToHash("DashingForward");

    private readonly int DashRightHash = Animator.StringToHash("DashingRight");

    //private Vector2 DashingDirectionInput;
    //private float RemainingDashTime;

    private const float CrossFadeDuration = 0.1f;

    private Vector3 dodgingDirectionInput;




    public PlayerDashingState(PlayerStateMachine stateMachine, Vector3 dodgingDirectionInput) : base(stateMachine)
    {

        this.dodgingDirectionInput= dodgingDirectionInput;
    }



    public override void Enter()
    {
        //DashingDirectionInput = stateMachine.InputReader.MovementValue;
        //RemainingDashTime = stateMachine.DashDuration;


        //momentum = stateMachine.Controller.velocity;
        //momentum.y = 0;

        stateMachine.Animator.CrossFadeInFixedTime(DashBlendTreeHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();

        Move(movement, deltaTime);


        if (_timerCounter >= _timer)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            _timerCounter = 0;
        }
        else { _timerCounter += Time.deltaTime;  }
    }

    public override void Exit()
    {

    }


}
