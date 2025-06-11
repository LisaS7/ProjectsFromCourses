using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    Animator animator;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float firingRate = 0.2f;

    public bool isFiring = false;

    Coroutine firingCoroutine;

    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
            animator.SetBool("isFiring", true);

        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }
}
