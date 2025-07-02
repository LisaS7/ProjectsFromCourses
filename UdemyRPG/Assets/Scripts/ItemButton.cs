using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ItemButton : MonoBehaviour
{
    public Image buttonImage;
    public TextMeshProUGUI quantityText;
    public int buttonValue;


    void Start()
    {

    }

    void Update()
    {

    }

    public void Press()
    {
        GameManager gm = GameManager.instance;
        string itemName = gm.itemsHeld[buttonValue];

        if (GameMenu.instance.menuPanel.activeInHierarchy)
        {
            if (itemName != "")
            {
                GameMenu.instance.SelectItem(gm.GetItemDetails(itemName));
            }
            else
            {
                Debug.Log($"Item not found: {itemName}");
            }
        }

        if (Shop.instance.shopMenu.activeInHierarchy)
        {
            Shop shop = Shop.instance;

            if (shop.buyMenu.activeInHierarchy)
            {
                string item = shop.ItemsForSale[buttonValue];
                shop.SelectBuyItem(gm.GetItemDetails(item));
            }

            if (shop.sellMenu.activeInHierarchy)
            {
                string item = gm.itemsHeld[buttonValue];
                shop.SelectSellItem(gm.GetItemDetails(item));
            }
        }
    }
}
