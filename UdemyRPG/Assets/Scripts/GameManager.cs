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
}
