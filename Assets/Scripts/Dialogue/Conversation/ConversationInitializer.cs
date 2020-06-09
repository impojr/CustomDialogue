using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationInitializer : MonoBehaviour
{
    private ConversationManager conversationManager;
    public Dictionary<string, Dialogue[]> dialogues;

    void Start()
    {
        conversationManager = FindObjectOfType<ConversationManager>();
        ConversationList.InitializeConversations();
    }

    public void TriggerConversation(ActorList actor)
    {
        if (actor == ActorList.BLOCKING_GUARD)
        {
            conversationManager.StartConversation(ConversationList.BLOCKING_GUARD);
        }
    }
}
