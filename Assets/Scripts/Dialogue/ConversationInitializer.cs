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
    }

    public void TriggerConversation(Actor actor)
    {
        if (actor.name == "Guard")
        {
            conversationManager.StartConversation(null, DialogueKeys.SHOW_ID_TO_GUARD);
        }
    }
}
