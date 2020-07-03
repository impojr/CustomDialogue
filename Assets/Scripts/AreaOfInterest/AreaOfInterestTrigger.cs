using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfInterestTrigger : MonoBehaviour
{
    private bool startInteraction = false;
    private AreaOfInterest interactWith;

    private ConversationInitializer conversationInitializer;

    private void Awake()
    {
        conversationInitializer = ConversationInitializer.Instance;
        interactWith = null;
    }

    private void Update()
    {
        if (startInteraction && Input.GetKeyDown(KeyCode.Space))
        {
            var objectWasDestroyed = interactWith.Interact();
            
            if (objectWasDestroyed)
            {
                RemoveObjectReferences();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AreaOfInterest")
        {
            startInteraction = true;
            interactWith = other.gameObject.GetComponent<AreaOfInterest>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AreaOfInterest")
        {
            RemoveObjectReferences();
        }
    }

    private void RemoveObjectReferences()
    {
        startInteraction = false;
        interactWith = null;
    }
}
