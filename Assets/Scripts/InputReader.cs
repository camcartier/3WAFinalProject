using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IMainActions
{
    private Controls controls;

    public event Action JumpEvent, DashEvent, UseEvent, MoveEvent, AttackEvent;

    void Start()
    {
        controls = new Controls();
        controls.Main.SetCallbacks(this);

        controls.Main.Enable();
    }

    void OnDestroy()
    {
        controls.Main.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }
        JumpEvent?.Invoke();

    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }
        AttackEvent?.Invoke();
        
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        DashEvent?.Invoke();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        MoveEvent?.Invoke();
    }
    public void OnUse(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }
        UseEvent?.Invoke();

    }





}
