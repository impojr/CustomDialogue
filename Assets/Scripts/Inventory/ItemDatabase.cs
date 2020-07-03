using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemId
{
    None,
    ID,
    AutospyReport
}

public static class ItemDatabase
{
    public static Dictionary<ItemId, Item> Items = new Dictionary<ItemId, Item>();

    public static void Initialize()
    {
        Items.Add(ItemId.ID, new Item("ID", "My ID. Lets me enter crime scenes.", "ID"));
        Items.Add(ItemId.AutospyReport, new Item("Autopsy Report", "The preliminary autopsy report. Has some details in them.", "PRELIM_AUTOPSY"));
    }

    public static Item GetItem(ItemId itemId)
    {
        return Items[itemId];
    }
}