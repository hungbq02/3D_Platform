﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Animator animator;
    private PlayerInputHandler inputHandler;

    private Vector3 moveDirection;
    public float moveSpeed = 4f;
    public float jumpForce = 10.0f;
    public float rotationSpeed = 10f;



    #region Variables: Ground
    [Header("Ground Check")]
    public float GroundedOffset = -0.05f;
    public float GroundedRadius = 0.07f;
    public LayerMask GroundLayers;
    bool isGrounded = true;

    private bool canJump = true;
    #endregion
    public bool IsGrounded => isGrounded;
    public Rigidbody Rb => rb;
    public Vector3 MoveDirection => moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputHandler = GetComponent<PlayerInputHandler>();
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        HandleMovementInput();
        // Check jump if player is grounded
        if (isGrounded && inputHandler.JumpTriggered && canJump)
        {
            Jump();
        }
        UpdateAnimator();
        CheckJump();

    }

    private void FixedUpdate()
    {
        CheckGrounded();
        RotatePlayer();
        MovePlayer();
    }

    private void HandleMovementInput()
    {
        Vector2 inputVector = inputHandler.MoveInput;
        moveDirection = new Vector3(-inputVector.y, 0, inputVector.x);
    }

    private void MovePlayer()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * moveDirection);
    }

    private void RotatePlayer()
    {
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }
    }
    private void UpdateAnimator()
    {
        animator.SetFloat("speed", moveDirection.magnitude * moveSpeed);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void Jump()
    {
        isGrounded = false;
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetTrigger("jump");
    }
    private void CheckJump()
    {
        if (rb.velocity.y > 0.1f)
        {
            canJump = false;
            return;
        }
        canJump = true;
        inputHandler.ResetJumpTrigger();
    }
    private void CheckGrounded()
    {
        if (rb.velocity.y > 0.1f) return;
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
            transform.position.z);
        isGrounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);

        /*    private void OnDrawGizmosSelected()
            {
                Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
                Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

                if (isGrounded) Gizmos.color = transparentGreen;
                else Gizmos.color = transparentRed;

                // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
                Gizmos.DrawSphere(
                    new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z),
                    GroundedRadius);
            }*/
    }
}