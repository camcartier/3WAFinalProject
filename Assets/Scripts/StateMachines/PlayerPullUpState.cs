using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPullUpState : PlayerBaseState
{

    private readonly int PullUpHash = Animator.StringToHash("pullup");
    private const float CrossFadeDuration = 0.1f;

    //this vector is used to tp the player on the spot the pullup anim ends at
    private readonly Vector3 Offset = new Vector3(0f, 2.5f, 1.25f);

    public PlayerPullUpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Controller.enabled = false;
        stateMachine.Animator.CrossFadeInFixedTime(PullUpHash, CrossFadeDuration);  
    }

    public override void Tick(float deltaTime)
    {
        if (stateMachine.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            return;
        }

        stateMachine.transform.Translate(Offset, Space.Self);

        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }

    public override void Exit()
    {
        //we are resetting the velocity to avoid weird movement at let go
        //else the game assumes we've been falling

        stateMachine.Controller.Move(Vector3.zero);
        stateMachine.ForceReceiver.Reset();

        stateMachine.Controller.enabled = true;
    }


}
