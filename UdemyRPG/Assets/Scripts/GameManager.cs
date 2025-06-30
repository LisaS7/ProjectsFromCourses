using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Main")]
    public static GameManager instance;
    public CharStats[] playerStats;

    [Header("Game Status")]
    public bool menuActive, dialogActive, fadeActive;

    [Header("Items")]
    public string[] itemsHeld;
    public int[] itemsQuantity;
    public Item[] referenceItems;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (menuActive || dialogActive || fadeActive)
        {
            PlayerController.instance.canMove = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
        }
    }

    public Item GetItemDetails(string itemNeeded)
    {
        for (int i = 0; i < referenceItems.Length; i++)
        {
            if (string.Equals(referenceItems[i].itemName, itemNeeded, System.StringComparison.OrdinalIgnoreCase))
            {
                return referenceItems[i];
            }
        }
        return null;
    }

    public void SortItems()
    {
        bool itemAfterSpace = true;

        while (itemAfterSpace)
        {
            itemAfterSpace = false;
            for (int i = 0; i < itemsHeld.Length - 1; i++)
            {
                if (itemsHeld[i] == "")
                {
                    itemsHeld[i] = itemsHeld[i + 1];
                    itemsHeld[i + 1] = "";

                    itemsQuantity[i] = itemsQuantity[i + 1];
                    itemsQuantity[i + 1] = 0;

                    if (itemsHeld[i] != "")
                    {
                        itemAfterSpace = true;
                    }
                }
            }
        }
    }
}
