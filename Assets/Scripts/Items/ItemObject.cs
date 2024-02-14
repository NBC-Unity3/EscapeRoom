using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData item;

    public string GetInteractPrompt()
    {
        return $"{item.displayName}";
    }

    public void OnInteract()
    {
        Inventory.instance.AddItem(item);
        Destroy(gameObject);
    }

    public void OnInteractWithKey() 
    {
        Debug.Log("");
    }
}
