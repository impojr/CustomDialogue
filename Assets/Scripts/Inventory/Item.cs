using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public Sprite image;
    public string description;

    public Item(string name, string description, string nameInResourcesFolder)
    {
        this.name = name;
        this.description = description;
        image = Resources.Load<Sprite>("Images/Items/" + nameInResourcesFolder);
    }
}
