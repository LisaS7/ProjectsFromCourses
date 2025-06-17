using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    Animator animator;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingVariance = 0f;
    [SerializeField] float minFiringRate = 0.1f;

    [HideInInspector] public bool isFiring = false;

    Coroutine firingCoroutine;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (useAI)
        {
            isFiring = true;
        }
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
                rb.linearVelocity = firePoint.up * projectileSpeed;
            }

            Destroy(instance, projectileLifetime);
            float fireTime = Random.Range(baseFiringRate - firingVariance, baseFiringRate + firingVariance);
            fireTime = Mathf.Clamp(fireTime, minFiringRate, float.MaxValue);
            yield return new WaitForSeconds(fireTime);
        }
    }
}
