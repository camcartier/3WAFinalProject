using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHangingState : PlayerBaseState
{
    private Vector3 momentum;
    private CharacterController CharacterController;

    //private Vector3 closestPoint;
    private Vector3 ledgeForward;

    private readonly int HangingHash = Animator.StringToHash("hanging");
    private const float CrossFadeDuration = 0.1f;

    public PlayerHangingState(PlayerStateMachine stateMachine, Vector3 ledgeForward) : base(stateMachine) 
    {
        this.ledgeForward = ledgeForward;
    }

    public override void Enter()
    {
        Debug.Log("ledge");
        Debug.Log("I entered hanging state");
        /*
        momentum = stateMachine.Controller.velocity;
        momentum.y = 0;
        momentum.x = 0;
        momentum.z = 0;
        */
        CharacterController = stateMachine.Controller;
        CharacterController.enabled = false;

        stateMachine.ForceReceiver.Reset();

        stateMachine.transform.rotation = Quaternion.LookRotation(ledgeForward, Vector3.up);

        stateMachine.Animator.CrossFadeInFixedTime(HangingHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {   
        
        if (stateMachine.InputReader.MovementValue.y < 0f)
        {
            stateMachine.Controller.Move(Vector3.zero);
            stateMachine.ForceReceiver.Reset();
            stateMachine.SwitchState(new PlayerFallingState(stateMachine));
        }
        
    }
    public override void Exit()
    {
        CharacterController.enabled = true;
    }
}
