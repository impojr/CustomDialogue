using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemList
{
    public static Item ID = new Item { name = "ID", description = "MY ID. Lets me enter crime scenes.", image = Resources.Load<Sprite>("Images/Items/ID") };
    public static Item TEST = new Item { name = "TEST", description = "MY ID. Lets me enter crime scenes.", image = Resources.Load<Sprite>("Images/Items/TEST") };
    public static Item RAND = new Item { name = "RAND", description = "MY ID. Lets me enter crime scenes.", image = Resources.Load<Sprite>("Images/Items/RAND") };
}
