using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    public GameObject shopMenu;
    public GameObject buyMenu;
    public GameObject sellMenu;
    public TextMeshProUGUI goldText;


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

        goldText.text = GameManager.instance.currentGold.ToString();
    }

    public void CloseShop()
    {
        shopMenu.SetActive(false);
        GameManager.instance.shopActive = true;
    }

    public void OpenBuyMenu()
    {
        buyMenu.SetActive(true);
        sellMenu.SetActive(false);
    }

    public void OpenSellMenu()
    {
        buyMenu.SetActive(false);
        sellMenu.SetActive(true);
    }
}
