using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : Singleton<EventTrigger>
{
    public AfterEventList eventToTrigger;
    public TriggerType triggerType;

    private EventManager eventManager;
    private DialogueManager dialogueManager;
    private bool canTriggerEvent;

    void Awake()
    {
        eventManager = EventManager.Instance;
        dialogueManager = DialogueManager.Instance;
        canTriggerEvent = false;
    }

    void Update()
    {
        if (canTriggerEvent && Input.GetKeyDown(KeyCode.Space) && !dialogueManager.canvasOpen)
        {
            eventManager.TriggerEvent(eventToTrigger);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (triggerType == TriggerType.COLLISION)
            {
                eventManager.TriggerEvent(eventToTrigger);
            } else if (triggerType == TriggerType.INTERACTION)
            {
                canTriggerEvent = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (triggerType == TriggerType.INTERACTION)
        {
            canTriggerEvent = false;
        }
    }
}