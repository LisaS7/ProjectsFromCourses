using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D bulletRB;
    PlayerMovement player;
    float bulletSpeed = 2f;
    float xSpeed;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }


    void Update()
    {
        bulletRB.linearVelocityX = xSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}
