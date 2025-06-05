using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D playerRB;
    Animator animator;
    [SerializeField] float runSpeed = 5f;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        Run();
        FlipSprite();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

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
}
