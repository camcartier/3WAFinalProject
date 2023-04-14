using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
    }

    protected void ReturnToLocomotion()
    {
        if (stateMachine.Targeter.CurrentTarget != null)
        {
            stateMachine.SwitchState(new PlayerTargetingState(stateMachine));

        }
        else
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }
    }


    protected void FaceTarget()
    {
        if (stateMachine.Targeter.CurrentTarget == null) { return;  }

        Vector3 LookPos = stateMachine.Targeter.CurrentTarget.transform.position - stateMachine.transform.position;
        LookPos.y = 0f;

        stateMachine.transform.rotation = Quaternion.LookRotation(LookPos);
    }




    #region testing
    /*
    protected void Dash(Vector3 motion, float deltaTime)
    {

    }
    */
    #endregion
}
