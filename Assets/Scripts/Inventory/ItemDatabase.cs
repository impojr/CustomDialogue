using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemId
{
    ID,
    AutospyReport
}

public static class ItemDatabase
{
    public static Item ID = new Item(ItemId.ID, "ID", "My ID. Lets me enter crime scenes.", "ID");
    public static Item PRELIM_AUTOPSY = new Item(ItemId.AutospyReport, "Autopsy Report", "The preliminary autopsy report. Has some details in them.", "PRELIM_AUTOPSY");
}