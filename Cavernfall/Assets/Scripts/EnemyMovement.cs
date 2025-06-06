using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D enemyRB;

    [SerializeField] float moveSpeed = 1f;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        enemyRB.linearVelocity = new Vector2(moveSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        FlipEnemy();
    }

    void FlipEnemy()
    {
        transform.localScale = new Vector2(-Mathf.Sign(enemyRB.linearVelocityX), 1f);
    }
}
