using UnityEngine;

public enum ItemType
{
    Equipable,
    Consumable
}
public enum ConsumableType
{
    Health,
    Stamina,
    Invincibility,
    SpeedBoost,
    JumpBoost
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

[CreateAssetMenu(fileName ="Item",menuName ="new Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType itemType;
    public ConsumableType consumType;
    //public Sprite icon;

    //[Header("Stacking")]
    //public bool canStack;
    //public int maxStackAmount;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;

    public bool IsGodMode;
}
