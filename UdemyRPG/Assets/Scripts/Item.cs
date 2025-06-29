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
}
