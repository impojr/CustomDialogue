using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public AfterEventList eventToTrigger;

    private EventManager eventManager;

    void Awake()
    {
        eventManager = FindObjectOfType<EventManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            eventManager.TriggerEvent(eventToTrigger);
        }
    }
}