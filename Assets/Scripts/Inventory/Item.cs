using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public ItemId id;
    public string name;
    public Sprite image;
    public string description;

    public Item(ItemId id, string name, string description, string nameInResourcesFolder)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        image = Resources.Load<Sprite>("Images/Items/" + nameInResourcesFolder);
    }
}
