using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
    private bool startConversation = false;

    private ConversationManager conversationManager;

    void Awake()
    {
        conversationManager = FindObjectOfType<ConversationManager>();
    }

    void Update()
    {
        if (startConversation && Input.GetKeyDown(KeyCode.Space)) {
            conversationManager.StartConversation();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger " + other.tag);
        if (other.tag == "NPC")
        {
            startConversation = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            startConversation = false;
        }
    }
}
