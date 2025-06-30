using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    [Header("Main")]
    public GameObject menuPanel;
    public GameObject[] windows;
    private CharStats[] playerData;

    [Space]
    [Header("Character Summary")]
    public TextMeshProUGUI[] nameText, HPText, MPText, levelText, expText;
    public Slider[] expSlider;
    public Image[] charImage;
    public GameObject[] charStatHolder;

    [Space]
    [Header("Stats Details")]
    public GameObject[] playerButtons;
    public TextMeshProUGUI statsName, statsHP, statsMP, statsStrength, statsDefence, statsEquippedWeapon, statsWeaponPower, statsEquippedArmour, statsArmourPower, statsExp;
    public Image statsImage;

    [Space]
    [Header("Items")]
    public ItemButton[] itemButtons;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (menuPanel.activeInHierarchy)
            {
                CloseMenu();
            }
            else
            {
                menuPanel.SetActive(true);
                UpdateMainStats();
                GameManager.instance.menuActive = true;
            }
        }
    }

    public void UpdateMainStats()
    {
        // cache ref
        playerData = GameManager.instance.playerStats;

        if (playerData == null || playerData.Length == 0)
        {
            Debug.LogWarning("playerData is null or empty.");
            return;
        }

        for (int i = 0; i < playerData.Length; i++)
        {
            if (playerData[i].gameObject.activeInHierarchy)
            {
                CharStats player = playerData[i];

                charStatHolder[i].SetActive(true);
                nameText[i].text = player.charName;
                HPText[i].text = $"HP: {player.currentHP}/{player.maxHP}";
                MPText[i].text = $"MP: {player.currentMP}/{player.maxMP}";
                levelText[i].text = $"Level: {player.playerLevel}";
                expText[i].text = $"{player.currentExp}/{player.expToNextLevel[player.playerLevel]}";
                expSlider[i].maxValue = player.expToNextLevel[player.playerLevel];
                expSlider[i].value = player.currentExp;
                charImage[i].sprite = player.charImage;
            }
            else
            {
                charStatHolder[i].SetActive(false);
            }
        }
    }

    public void ToggleWindow(int windowNumber)
    {
        UpdateMainStats();

        for (int i = 0; i < windows.Length; i++)
        {
            if (i == windowNumber)
            {
                bool isActive = windows[i].activeInHierarchy;
                windows[i].SetActive(!isActive);

                if (isActive && i == 0)
                {
                    ShowItems();
                }
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }

    public void CloseMenu()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }

        menuPanel.SetActive(false);

        GameManager.instance.menuActive = false;
    }

    public void OpenStats()
    {

        UpdateMainStats();

        StatsChar(0);

        for (int i = 0; i < playerButtons.Length; i++)
        {
            playerButtons[i].SetActive(playerData[i].gameObject.activeInHierarchy);
            playerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = playerData[i].charName;
        }
    }

    public void StatsChar(int selected)
    {
        CharStats player = playerData[selected];

        statsImage.sprite = player.charImage;
        statsName.text = player.charName;
        statsHP.text = $"{player.currentHP}/{player.maxHP}";
        statsMP.text = $"{player.currentMP}/{player.maxMP}";
        statsStrength.text = $"{player.strength}";
        statsDefence.text = $"{player.defence}";

        if (player.equippedWeapon != "")
        {
            statsEquippedWeapon.text = $"{player.equippedWeapon}";
        }


        statsWeaponPower.text = $"{player.weaponPower}";

        if (player.equippedArmour != "")
        {
            statsEquippedArmour.text = $"{player.equippedArmour}";
        }


        statsArmourPower.text = $"{player.armourPower}";
        statsExp.text = $"{player.expToNextLevel[player.playerLevel] - player.currentExp}";

    }

    public void ShowItems()
    {
        GameManager.instance.SortItems();

        for (int i = 0; i < itemButtons.Length; i++)
        {
            // cache refs
            ItemButton itemBtn = itemButtons[i];
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
