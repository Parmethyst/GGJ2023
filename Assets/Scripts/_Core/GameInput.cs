using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameInput : MonoBehaviour
{
    private PlayerInput playerInput;

    void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
        playerInput.Player.Jump.performed += Jump_performed;
    }
    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("JUMP");
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInput.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
