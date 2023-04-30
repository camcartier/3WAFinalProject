using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUsingSpellState : PlayerBaseState
{


    Vector3 movement = new Vector3();


    private readonly int UsingSpellHash = Animator.StringToHash("usingSpell");
    private const float CrossFadeDuration = 0.1f;

    public PlayerUsingSpellState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("use");

        stateMachine.InputReader.UseEvent += OnUse;

        stateMachine.GameManager._isUsingSpell = true;
        stateMachine.PlayerData._currentMana -= 0.5f;

        //stateMachine.Animator.CrossFadeInFixedTime(UsingSpellHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        movement = CalculateMovement();

        Move(movement * stateMachine._movementSpeed, deltaTime);

        /*
        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime, deltaTime);
            return;
        }
        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime, deltaTime); */


        FaceMovementDirection(movement, deltaTime);




        if (stateMachine.PlayerData._currentMana <= 0)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }
        

    }

    public override void Exit()
    {
        stateMachine.GameManager._isUsingSpell = false;

        stateMachine.InputReader.UseEvent -= OnUse;
    }


    // a deplacer vers base state?
    private Vector3 CalculateMovement()
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        forward.y = 0; right.y = 0;

        forward.Normalize(); right.Normalize();

        return forward * stateMachine.InputReader.MovementValue.y + right * stateMachine.InputReader.MovementValue.x;
    }

    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation,
            Quaternion.LookRotation(movement),
            deltaTime * stateMachine.RotationDamping);
    }

    private void OnUse()
    {
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }

}
