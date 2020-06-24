using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;
    public Sprite image;
    public string description;

    public static Item CreateItem(string _name, string _description, string nameInResourcesFolder)
    {
        return new Item
        {
            name = _name,
            description = _description,
            image = Resources.Load<Sprite>("Images/Items/" + nameInResourcesFolder)
        };
    }
}
