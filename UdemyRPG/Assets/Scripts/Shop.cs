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
        buyMenu.SetActive(false);
        sellMenu.SetActive(true);

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
}
