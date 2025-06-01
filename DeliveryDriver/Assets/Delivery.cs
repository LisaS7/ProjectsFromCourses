using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 noPackageColour = new Color32(1,1,1,1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Oof!!");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            SpriteRenderer packageRenderer = collision.GetComponent<SpriteRenderer>();
            if (packageRenderer != null)
            {
                spriteRenderer.color = packageRenderer.color;
            }
            hasPackage = true;
            Destroy(collision.gameObject, destroyDelay);
        }

        if (collision.tag == "Customer" && hasPackage)
        {
            spriteRenderer.color = noPackageColour;
            Debug.Log("Delivered!");
            hasPackage = false;
        }
    }
}
