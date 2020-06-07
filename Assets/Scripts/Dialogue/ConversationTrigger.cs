﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    private bool startConversation = false;
    private Actor conversationWith;

    private ConversationInitializer conversationInitializer;

    void Awake()
    {
        conversationInitializer = FindObjectOfType<ConversationInitializer>();
        conversationWith = null;
    }

    void Update()
    {
        if (startConversation && Input.GetKeyDown(KeyCode.Space)) {
            conversationInitializer.TriggerConversation(conversationWith);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger " + other.tag);
        if (other.tag == "NPC")
        {
            startConversation = true;
            conversationWith = other.gameObject.GetComponent<Actor>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            startConversation = false;
            conversationWith = null;
        }
    }
}
