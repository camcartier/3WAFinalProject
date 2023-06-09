using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }

    [field: SerializeField] public Targeter Targeter { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }

    [field: SerializeField] public LedgeDetector LedgeDetector { get; private set; }
    [field: SerializeField] public GameObject HangingPanel { get; private set; }

    [field: SerializeField] public float _movementSpeed { get; private set; }
    [field: SerializeField] public float _jumpForwardSpeed { get; private set; }
    [field: SerializeField] public float _doubleJumpForwardSpeed { get; private set; }
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public float DoubleJumpForce { get; private set; }

    [field: SerializeField] public float DashForce { get; private set; }
    [field: SerializeField] public float DashDuration { get; private set; }
    [field: SerializeField] public float DashDistance { get; private set; }


    [field: SerializeField] public float RotationDamping { get; private set; }


    [field: SerializeField] public PlayerData PlayerData { get; private set; }
    [field: SerializeField] public GameManager GameManager { get; private set; }


    public Transform MainCameraTransform { get; private set; }

    void Start()
    {
        MainCameraTransform = Camera.main.transform;

        SwitchState(new PlayerFreeLookState(this));
    }

}
