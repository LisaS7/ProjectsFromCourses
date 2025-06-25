using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;

    Animator animator;

    public static PlayerController instance;

    public string areaTransitionName;
    Vector3 bottomLeftLimit;
    Vector3 topRightLimit;

    public bool canMove = true;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (canMove)
        {
            rb.linearVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

        animator.SetFloat("moveX", rb.linearVelocityX);
        animator.SetFloat("moveY", rb.linearVelocityY);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            if (canMove)
            {
                animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
            Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y),
            transform.position.z);

    }

    public void SetBounds(Vector3 bottomLeft, Vector3 topRight)
    {
        bottomLeftLimit = bottomLeft + new Vector3(1f, 1f, 0);
        topRightLimit = topRight + new Vector3(-1f, -1f, 0);
    }

}
