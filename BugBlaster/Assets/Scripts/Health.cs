using UnityEngine;

public class Health : MonoBehaviour
{
    Animator animator;
    [SerializeField] int health = 50;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    public void TakeDamage(int value)
    {

        if (animator != null)
        {
            animator.SetTrigger("isHit"); // Use SetTrigger if it's a trigger parameter
        }

        health -= value;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
