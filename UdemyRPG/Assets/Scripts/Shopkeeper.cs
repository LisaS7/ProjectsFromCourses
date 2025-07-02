using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    bool canOpen;
    public string[] ItemsForSale = new string[35];

    void Start()
    {

    }

    void Update()
    {
        if (canOpen && Input.GetButtonDown("Fire1") && PlayerController.instance.canMove && !Shop.instance.shopMenu.activeInHierarchy)
        {
            Shop.instance.ItemsForSale = ItemsForSale;
            Shop.instance.OpenShop();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canOpen = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canOpen = false;
        }
    }
}
