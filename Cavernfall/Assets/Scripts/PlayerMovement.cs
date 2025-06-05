using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D playerRB;
    Animator animator;
    BoxCollider2D playerCollider;
    float baseGravity;

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 8f;
    [SerializeField] float climbSpeed = 4f;



    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
        baseGravity = playerRB.gravityScale;
    }


    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

    }

    void OnJump(InputValue value)
    {
        if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (value.isPressed)
        {
            playerRB.linearVelocity += new Vector2(0f, jumpSpeed);
        }

    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, playerRB.linearVelocityY);
        playerRB.linearVelocity = playerVelocity;

        bool hasHorizontalSpeed = Mathf.Abs(playerRB.linearVelocityX) > Mathf.Epsilon;
        animator.SetBool("isRunning", hasHorizontalSpeed);

    }

    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(playerRB.linearVelocityX) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {

            transform.localScale = new Vector2(Mathf.Sign(playerRB.linearVelocityX), 1f);
        }

    }

    void ClimbLadder()
    {
        bool isClimbing = playerCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"));
        if (!isClimbing)
        {
            playerRB.gravityScale = baseGravity;
            return;
        }

        Vector2 climbVelocity = new Vector2(playerRB.linearVelocityX, moveInput.y * climbSpeed);
        playerRB.linearVelocity = climbVelocity;
        playerRB.gravityScale = 0f;

        bool hasVerticalSpeed = Mathf.Abs(playerRB.linearVelocityY) > Mathf.Epsilon;
        animator.SetBool("isClimbing", hasVerticalSpeed);

    }

}
