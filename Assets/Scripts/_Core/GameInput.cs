using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameInput : MonoBehaviour
{
    private PlayerInput playerInput;
    public Action OnJumpInput;
    public bool IsJumpPressed { get; private set; }

    void OnEnable()
    {
        IsJumpPressed = false;
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
        playerInput.Player.Jump.performed += Jump_performed;
        playerInput.Player.Jump.started += Jump_started;
        playerInput.Player.Jump.canceled += Jump_cancelled;
    }
    void OnDisable()
    {
        playerInput.Player.Jump.performed += Jump_performed;
        playerInput.Player.Jump.started += Jump_started;
        playerInput.Player.Jump.canceled += Jump_cancelled;
    }
    void Update()
    {
        if (IsJumpPressed) OnJumpInput?.Invoke();
    }
    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        IsJumpPressed = true;
    }
    private void Jump_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        IsJumpPressed = true;
    }
    private void Jump_cancelled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        IsJumpPressed = false;
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
