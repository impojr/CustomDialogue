using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public List<Item> items;

    public void Awake()
    {
        ItemDatabase.Initialize();
        items = new List<Item> { ItemDatabase.GetItem(ItemId.ID) };
    }
    
    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
