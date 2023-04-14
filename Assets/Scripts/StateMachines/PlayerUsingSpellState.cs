using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUsingSpellState : PlayerBaseState
{

    [SerializeField] PlayerData PlayerData;

    private readonly int UsingSpellHash = Animator.StringToHash("usingSpell");
    private const float CrossFadeDuration = 0.1f;

    public PlayerUsingSpellState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(UsingSpellHash, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {


        if (PlayerData._currentMana <= 0)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }
        
    }
    public override void Exit()
    {

    }
}
