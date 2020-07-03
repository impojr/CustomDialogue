using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfInterest : MonoBehaviour
{
    public ItemId itemToPickUp;
    public string dialogueKey;
    public bool destroyOnInteract;

    public bool Interact()
    {
        if (itemToPickUp != ItemId.None)
        {
            InventoryManager.Instance.AddItem(itemToPickUp);
        }

        DialogueInitializer.Instance.TriggerDialogue(dialogueKey, false);

        if (destroyOnInteract)
        {
            Destroy(gameObject);
        }

        return destroyOnInteract;
    }
}
