using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Other,
    Equipable,
    Consumable,
}

public enum ConsumableType  // 나중에 문서 같은 읽기 아이템을 추가 할 때 여기서 변경하면 될 것 같음.
{
    Book
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public string content;
}


[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefab;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumalbe")]
    public ItemDataConsumable[] consumables;

    [Header("Equip")]
    public GameObject equipPrefab;
}
