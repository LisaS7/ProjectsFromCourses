using UnityEngine;

public class CharStats : MonoBehaviour
{
    public string charName;
    public Sprite charImage;

    public int playerLevel = 1;
    public int currentExp;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseExp = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int[] mpLevelBonus;
    public int currentMP;
    public int maxMP = 100;

    public int strength;
    public int defence;
    public int weaponPower;
    public int armourPower;
    public string equippedweapon;
    public string equippedArmour;


    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseExp;

        for (int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddExp(500);
        }
    }

    public void AddExp(int value)
    {
        currentExp += value;

        if (playerLevel < maxLevel)
        {
            if (currentExp > expToNextLevel[playerLevel])
            {
                currentExp -= expToNextLevel[playerLevel];
                playerLevel++;

                // Add strength or defence
                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defence++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;

                maxMP += mpLevelBonus[playerLevel];
                currentMP = maxMP;
            }
        }

        else
        {
            currentExp = 0;
        }

    }
}
