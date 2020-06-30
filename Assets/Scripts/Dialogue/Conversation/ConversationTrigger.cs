using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : Singleton<ConversationTrigger>
{
    private bool startConversation = false;
    private ActorSelector conversationWith;

    private ConversationInitializer conversationInitializer;

    void Awake()
    {
        conversationInitializer = ConversationInitializer.Instance;
        conversationWith = null;
    }

    void Update()
    {
        if (startConversation && Input.GetKeyDown(KeyCode.Space)) {
            conversationInitializer.TriggerConversation(conversationWith.actor);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            startConversation = true;
            conversationWith = other.gameObject.GetComponent<ActorSelector>();
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
