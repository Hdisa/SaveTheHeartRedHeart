using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private CharacterController characterController;
    public static Action OnMoveForward;
    public static Action OnMoveLeft;
    public static Action OnMoveBack;
    public static Action OnMoveRight;
    public static Action OnJump;

    private void Start()
    {
        InitializeComponents();
    }
    
    private void InitializeComponents()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKey(playerSettings.forward))
            OnMoveForward.Invoke();
        if (Input.GetKey(playerSettings.left))
            OnMoveLeft.Invoke();
        if (Input.GetKey(playerSettings.back))
            OnMoveBack.Invoke();
        if (Input.GetKey(playerSettings.right))
            OnMoveRight.Invoke();
        if (Input.GetKey(playerSettings.jump) && characterController.isGrounded)
            OnJump.Invoke();
    }
}