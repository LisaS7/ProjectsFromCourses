using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Type")]
    public bool isItem, isWeapon, isArmour;

    [Header("Item Info")]
    public string itemName;
    public string description;
    public int value;
    public Sprite itemSprite;

    [Header("Stat Modification")]
    public int statModifier;
    public bool affectHP, affectMP, affectStrength, affectDefence;

    public int itemStrength;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Use(int targetChar)
    {
        CharStats selectedChar = GameManager.instance.playerStats[targetChar];

        if (isItem)
        {
            if (affectHP)
            {
                selectedChar.currentHP += statModifier;

                if (selectedChar.currentHP > selectedChar.maxHP)
                {
                    selectedChar.currentHP = selectedChar.maxHP;
                }
            }

            if (affectMP)
            {
                selectedChar.currentMP += statModifier;

                if (selectedChar.currentMP > selectedChar.maxMP)
                {
                    selectedChar.currentMP = selectedChar.maxMP;
                }
            }

            if (affectStrength)
            {
                selectedChar.strength += statModifier;
            }

            if (affectDefence)
            {
                selectedChar.defence += statModifier;
            }

        }
        if (isWeapon)
        {
            if (selectedChar.equippedWeapon != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedWeapon);
            }

            selectedChar.equippedWeapon = itemName;
            selectedChar.weaponPower = itemStrength;
        }

        if (isArmour)
        {
            if (selectedChar.equippedArmour != "")
            {
                GameManager.instance.AddItem(selectedChar.equippedArmour);
            }

            selectedChar.equippedArmour = itemName;
            selectedChar.armourPower = itemStrength;
        }

        GameManager.instance.RemoveItem(itemName);
    }
}
