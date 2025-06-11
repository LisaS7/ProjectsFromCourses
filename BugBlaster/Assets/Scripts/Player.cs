using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Animator animator;
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 8f;

    Vector2 minBound;
    Vector2 maxBound;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        InitBounds();
    }

    void Update()
    {

        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    void Move()
    {
        bool isMoving = rawInput != Vector2.zero;
        animator.SetBool("isMoving", isMoving);

        Vector2 delta = moveSpeed * Time.deltaTime * rawInput;
        Vector2 newPosition = new()
        {
            x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + paddingLeft, maxBound.x - paddingRight),
            y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + paddingBottom, maxBound.y - paddingTop)
        };

        transform.position = newPosition;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
