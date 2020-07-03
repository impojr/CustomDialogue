using System;
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

    internal void AddItem(ItemId itemId)
    {
        items.Add(ItemDatabase.GetItem(itemId));
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public void RemoveItem(ItemId itemId)
    {
        items.Remove(ItemDatabase.GetItem(itemId));
    }
}
