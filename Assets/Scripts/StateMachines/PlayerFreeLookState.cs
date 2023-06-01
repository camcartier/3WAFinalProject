using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerFreeLookState : PlayerBaseState
{
    //public GameManager GameManager;
    private float dashingCooldown = 2f;
    private float dashingCooldownCounter = 2f;

    Vector3 movement = new Vector3();
    private const float AnimatorDampTime = 0.1f;


    //we attribute an int to this string for faster code
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreelookSpeed");
    private readonly int FreeLookBlendTreeHash = Animator.StringToHash("FreeLookBlendTree");


    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) {}


    public override void Enter()
    {
        stateMachine.InputReader.JumpEvent += OnJump;
        stateMachine.InputReader.DashEvent += OnDash;

        //stateMachine.InputReader.TargetEvent += OnTarget;
        stateMachine.InputReader.TargetEvent += OnCancel;

        stateMachine.InputReader.UseEvent += OnUse;

        stateMachine.Animator.Play(FreeLookBlendTreeHash);
    }
    public override void Tick(float deltaTime)
    {
        movement = CalculateMovement();
        /*
        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0f;
        movement.z = stateMachine.InputReader.MovementValue.y;*/

        Move(movement * stateMachine._movementSpeed, deltaTime);

        //stateMachine.Controller.Move(movement * Time.deltaTime * stateMachine._movementSpeed);

        if (stateMachine.InputReader.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime, deltaTime);
            stateMachine.GameManager.stepsDefault.Play();
            return;
        }
        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime, deltaTime);
        

        FaceMovementDirection(movement, deltaTime);
    }
    public override void Exit()
    {
        stateMachine.InputReader.JumpEvent -= OnJump;
        stateMachine.InputReader.DashEvent -= OnDash;

        //stateMachine.InputReader.TargetEvent -= OnTarget;
        stateMachine.InputReader.CancelEvent -= OnCancel;

        stateMachine.InputReader.UseEvent -= OnUse;

        stateMachine.GameManager.stepsDefault.Stop();
    }

    //old
    
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
    

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerJumpingState(stateMachine));
    }

    /*
    private void OnTarget()
    {
        if (!stateMachine.Targeter.SelectTarget()) { return; }
        stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
    }*/

    private void OnCancel()
    {
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }

    private void OnDash()
    {
        if (!stateMachine.GameManager._canDash)
        {
            Debug.Log("can't dash yet :-)");
            stateMachine.GameManager.MessagePanel.SetActive(true);
            stateMachine.GameManager.MessagePanel.GetComponentInChildren<TextMeshProUGUI>().text = ("can't dash yet :-)");
            return;
        }

        stateMachine.SwitchState(new PlayerDashingState(stateMachine));
        //stateMachine.SwitchState(new PlayerDashingState(stateMachine, stateMachine.InputReader.MovementValue));
    }

    private void OnUse()
    {
        stateMachine.SwitchState(new PlayerUsingSpellState(stateMachine));
    }
}
