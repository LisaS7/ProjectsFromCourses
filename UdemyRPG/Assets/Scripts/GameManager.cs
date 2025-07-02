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

    [Header("Currency")]
    public int currentGold;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        SortItems();
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

    public void AddItem(string item)
    {
        int newItemPosition = 0;
        bool foundSpace = false;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            if (itemsHeld[i] == "" || itemsHeld[i] == item)
            {
                newItemPosition = i;
                i = itemsHeld.Length;
                foundSpace = true;
            }
        }

        if (foundSpace)
        {
            bool itemExists = false;
            for (int i = 0; i < referenceItems.Length; i++)
            {
                if (referenceItems[i].itemName == item)
                {
                    itemExists = true;

                    i = referenceItems.Length;
                }
            }

            if (itemExists)
            {
                itemsHeld[newItemPosition] = item;
                itemsQuantity[newItemPosition]++;
            }
            else
            {
                Debug.LogError($"Item {item} not found");
            }
        }

        GameMenu.instance.ShowItems();
    }

    public void RemoveItem(string item)
    {
        int itemPosition = 0;
        bool foundItem = false;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
            if (itemsHeld[i] == item)
            {
                foundItem = true;
                itemPosition = i;

                i = itemsHeld.Length;
            }
        }

        if (foundItem)
        {
            itemsQuantity[itemPosition]--;

            if (itemsQuantity[itemPosition] <= 0)
            {
                itemsHeld[itemPosition] = "";
            }

            GameMenu.instance.ShowItems();
        }
        else
        {
            Debug.LogError($"Couldn't find {item}");
        }
    }
}
