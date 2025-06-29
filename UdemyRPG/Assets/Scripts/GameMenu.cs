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
        playerData = GameManager.instance.playerStats;

        for (int i = 0; i < playerData.Length; i++)
        {
            if (playerData[i].gameObject.activeInHierarchy)
            {
                charStatHolder[i].SetActive(true);
                nameText[i].text = playerData[i].charName;
                HPText[i].text = $"HP: {playerData[i].currentHP}/{playerData[i].maxHP}";
                MPText[i].text = $"MP: {playerData[i].currentMP}/{playerData[i].maxMP}";
                levelText[i].text = $"Level: {playerData[i].playerLevel}";
                expText[i].text = $"{playerData[i].currentExp}/{playerData[i].expToNextLevel[playerData[i].playerLevel]}";
                expSlider[i].maxValue = playerData[i].expToNextLevel[playerData[i].playerLevel];
                expSlider[i].value = playerData[i].currentExp;
                charImage[i].sprite = playerData[i].charImage;
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
                windows[i].SetActive(!windows[i].activeInHierarchy);
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

        // update stuff

        for (int i = 0; i < playerButtons.Length; i++)
        {
            playerButtons[i].SetActive(playerData[i].gameObject.activeInHierarchy);
            playerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = playerData[i].charName;
        }
    }

    public void StatsChar(int selected)
    {
        statsImage.sprite = playerData[selected].charImage;
        statsName.text = playerData[selected].charName;
        statsHP.text = $"{playerData[selected].currentHP}/{playerData[selected].maxHP}";
        statsMP.text = $"{playerData[selected].currentMP}/{playerData[selected].maxMP}";
        statsStrength.text = $"{playerData[selected].strength}";
        statsDefence.text = $"{playerData[selected].defence}";
        statsEquippedWeapon.text = $"{playerData[selected].equippedweapon}";
        statsWeaponPower.text = $"{playerData[selected].weaponPower}";
        statsEquippedArmour.text = $"{playerData[selected].equippedArmour}";
        statsArmourPower.text = $"{playerData[selected].armourPower}";
        statsExp.text = $"{playerData[selected].expToNextLevel}";

    }
}
