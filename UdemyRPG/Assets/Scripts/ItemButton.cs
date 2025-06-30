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

        if (itemName != "")
        {
            GameMenu.instance.SelectItem(gm.GetItemDetails(itemName));
        }
        else
        {
            Debug.Log($"Item not found: {itemName}");
        }
    }
}
