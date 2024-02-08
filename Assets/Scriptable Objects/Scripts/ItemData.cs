using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Other,
    Equipable,
    Consumable,
}

public enum ConsumableType  // ���߿� ���� ���� �б� �������� �߰� �� �� ���⼭ �����ϸ� �� �� ����.
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
