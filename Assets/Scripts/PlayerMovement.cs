using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    private Vector2 movementInput;
    private Rigidbody2D rb;
    private bool isMoving;

    [Header("Animation")]
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public bool IsMoving => isMoving;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movementInput * moveSpeed;
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (movementInput.sqrMagnitude < 0.01f)
        {
            animator.SetFloat("Speed", 0f);
            return;
        }

        animator.SetFloat("Speed", 1f);

        float x = movementInput.x;
        float y = movementInput.y;

        // SIDE movement (Left/Right)
        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            animator.SetInteger("Direction", 1);

            // Flip for right movement
            spriteRenderer.flipX = x > 0;
        }
        else
        {
            spriteRenderer.flipX = false;

            if (y > 0)
                animator.SetInteger("Direction", 2); // Forward (Up)
            else
                animator.SetInteger("Direction", 0); // Down
        }
    }

}
