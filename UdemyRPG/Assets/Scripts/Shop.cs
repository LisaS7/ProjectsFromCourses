using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public GameObject shopMenu;
    public GameObject buyMenu;
    public GameObject sellMenu;
    public TextMeshProUGUI goldText;

    public string[] ItemsForSale;

    public ItemButton[] buyItemButtons, sellItemButtons;

    public Item selectedItem;
    public TextMeshProUGUI buyItemName, buyItemDescription, buyItemValue;
    public TextMeshProUGUI sellItemName, sellItemDescription, sellItemValue;



    void Start()
    {
        instance = this;
    }

    void Update()
    {

    }

    public void OpenShop()
    {
        shopMenu.SetActive(true);
        GameManager.instance.shopActive = true;
        OpenBuyMenu();

        goldText.text = GameManager.instance.currentGold.ToString();
    }

    public void CloseShop()
    {
        shopMenu.SetActive(false);
        GameManager.instance.shopActive = false;
    }

    public void OpenBuyMenu()
    {
        buyItemButtons[0].Press();
        buyMenu.SetActive(true);
        sellMenu.SetActive(false);

        for (int i = 0; i < buyItemButtons.Length; i++)
        {
            // cache refs
            ItemButton itemBtn = buyItemButtons[i];
            GameManager gameManager = GameManager.instance;

            itemBtn.buttonValue = i;

            if (ItemsForSale[i] != "")
            {
                itemBtn.buttonImage.gameObject.SetActive(true);
                itemBtn.buttonImage.sprite = gameManager.GetItemDetails(ItemsForSale[i]).itemSprite;
                itemBtn.quantityText.text = "";
            }
            else
            {
                itemBtn.buttonImage.gameObject.SetActive(false);
                itemBtn.quantityText.text = "";
            }
        }
    }

    public void OpenSellMenu()
    {
        sellItemButtons[0].Press();
        buyMenu.SetActive(false);
        sellMenu.SetActive(true);
        ShowSellItems();
    }

    void ShowSellItems()
    {
        GameManager.instance.SortItems();

        for (int i = 0; i < sellItemButtons.Length; i++)
        {
            // cache refs
            ItemButton itemBtn = sellItemButtons[i];
            GameManager gameManager = GameManager.instance;

            itemBtn.buttonValue = i;

            if (!string.IsNullOrEmpty(gameManager.itemsHeld[i]))
            {
                itemBtn.buttonImage.gameObject.SetActive(true);
                itemBtn.buttonImage.sprite = gameManager.GetItemDetails(gameManager.itemsHeld[i]).itemSprite;
                itemBtn.quantityText.text = gameManager.itemsQuantity[i].ToString();
            }
            else
            {
                itemBtn.buttonImage.gameObject.SetActive(false);
                itemBtn.quantityText.text = "";
            }
        }
    }

    public void SelectBuyItem(Item item)
    {
        selectedItem = item;
        buyItemName.text = selectedItem.itemName;
        buyItemDescription.text = selectedItem.description;
        buyItemValue.text = "Value: " + selectedItem.value;
    }

    public void SelectSellItem(Item item)
    {
        selectedItem = item;
        sellItemName.text = selectedItem.itemName;
        sellItemDescription.text = selectedItem.description;
        sellItemValue.text = "Value: " + Mathf.FloorToInt(selectedItem.value * 0.7f);
    }

    public void BuyItem()
    {
        if (selectedItem != null)
        {

            GameManager gm = GameManager.instance;

            if (gm.currentGold >= selectedItem.value)
            {
                gm.currentGold -= selectedItem.value;
                gm.AddItem(selectedItem.itemName);
            }

            goldText.text = gm.currentGold.ToString();
        }
    }

    public void SellItem()
    {
        if (selectedItem != null)
        {
            GameManager gm = GameManager.instance;
            gm.currentGold += Mathf.FloorToInt(selectedItem.value * 0.75f);
            gm.RemoveItem(selectedItem.itemName);
            goldText.text = gm.currentGold.ToString();
        }

        ShowSellItems();
    }
}
