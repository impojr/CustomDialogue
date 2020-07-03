using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfInterest : MonoBehaviour
{
    public ItemId itemToPickUp;
    public string dialogueKey;
    public string eventToTrigger;
    public bool destroyOnInteract;

    public void Interact()
    {
        if (itemToPickUp != ItemId.None)
        {
            //InventoryManager.Instance.AddItem();
        }
    }
}
