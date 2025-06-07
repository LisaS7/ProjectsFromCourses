using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Animator animator;
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        Move();
    }

    void Move()
    {
        bool isMoving = rawInput != Vector2.zero;
        animator.SetBool("isMoving", isMoving);
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
}
