using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Android;

public class PlayerInputHandler : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction jumpAction;

    public Joystick joystick;
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
    private void Update()
    {
        // Check if joystick is not null and if it is being used
        if (joystick != null && (Mathf.Abs(joystick.Horizontal) > 0.1f || Mathf.Abs(joystick.Vertical) > 0.1f))
        {
            MoveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        }
    }
    private void OnMovePerformed(InputAction.CallbackContext context)
    {

        if (joystick == null || (Mathf.Abs(joystick.Horizontal) < 0.1f && Mathf.Abs(joystick.Vertical) < 0.1f))
        {
            MoveInput = context.ReadValue<Vector2>();
        }
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.zero;
    }

    private void OnJumpStarted(InputAction.CallbackContext context)
    {
        JumpTriggered = true;
    }
    public void OnJumpButtonPressed()
    {
        JumpTriggered = true;
    }
    public void ResetJumpTrigger()
    {
        JumpTriggered = false;
    }
}