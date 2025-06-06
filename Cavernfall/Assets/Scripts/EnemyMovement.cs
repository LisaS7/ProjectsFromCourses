using System.Collections;
using TreeEditor;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D enemyRB;

    [SerializeField] float moveSpeed = 1f;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        FaceDirection();
    }


    void Update()
    {
        enemyRB.linearVelocityX = moveSpeed;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("TRIGGER!" + gameObject.name);
        moveSpeed = -moveSpeed;
        FaceDirection();
    }

    // void FlipEnemy()
    // {
    //     transform.localScale = new Vector2(-Mathf.Sign(enemyRB.linearVelocityX), 1f);

    // }

    void FaceDirection()
    {
        transform.localScale = new Vector2(Mathf.Sign(moveSpeed), 1f);
    }
}
