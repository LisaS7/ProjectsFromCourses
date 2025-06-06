using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D playerRB;
    Animator animator;
    BoxCollider2D bodyCollider;
    CapsuleCollider2D feetCollider;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;

    float baseGravity;
    bool isAlive = true;
    Vector2 deathAction = new Vector2(5f, 15f);

    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 8f;
    [SerializeField] float climbSpeed = 4f;
    [SerializeField] float waterDrag = 5f;



    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider = GetComponent<BoxCollider2D>();
        feetCollider = GetComponent<CapsuleCollider2D>();
        baseGravity = playerRB.gravityScale;
    }


    void Update()
    {
        if (!isAlive) { return; }

        Run();
        FlipSprite();
        ClimbLadder();
        Die();

    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (value.isPressed)
        {
            playerRB.linearVelocity += new Vector2(0f, jumpSpeed);
        }

    }

    void OnFire(InputValue value)
    {
        if (!isAlive) { return; }
        Instantiate(bullet, gun.position, transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            playerRB.linearDamping = waterDrag;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            playerRB.linearDamping = 0f;
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
        bool isClimbing = feetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"));
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

    void Die()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            animator.SetTrigger("Dying");
            playerRB.linearVelocity = deathAction;
        }
    }

}
