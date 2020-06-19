using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public AfterEventList eventToTrigger;
    public TriggerType triggerType;

    private EventManager eventManager;
    private bool canTriggerEvent;

    void Awake()
    {
        eventManager = FindObjectOfType<EventManager>();
        canTriggerEvent = false;
    }

    void Update()
    {
        if (canTriggerEvent && Input.GetKeyDown(KeyCode.Space))
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