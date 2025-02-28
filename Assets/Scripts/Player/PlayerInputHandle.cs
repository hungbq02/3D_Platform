using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;

    public Vector2 MoveInput { get; private set; }
    public bool JumpTriggered { get; private set; }

    private void Awake()
    {
        var playerInput = GetComponent<PlayerInput>();

        // Get input actions from PlayerInput
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
    }

    private void OnEnable()
    {
        moveAction.performed += OnMovePerformed;
        moveAction.canceled += OnMoveCanceled;
        jumpAction.started += OnJumpStarted;
    }

    private void OnDisable()
    {
        moveAction.performed -= OnMovePerformed;
        moveAction.canceled -= OnMoveCanceled;
        jumpAction.started -= OnJumpStarted;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.zero;
    }

    private void OnJumpStarted(InputAction.CallbackContext context)
    {
        JumpTriggered = true;
    }

    public void ResetJumpTrigger()
    {
        JumpTriggered = false;
    }
}