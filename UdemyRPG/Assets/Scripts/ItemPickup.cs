using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private bool canPickUp;

    void Start()
    {

    }

    void Update()
    {
        if (canPickUp && Input.GetButtonDown("Fire1") && PlayerController.instance.canMove)
        {
            string itemName = GetComponent<Item>().itemName;
            GameManager.instance.AddItem(itemName);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canPickUp = true;
        }
    }
}
