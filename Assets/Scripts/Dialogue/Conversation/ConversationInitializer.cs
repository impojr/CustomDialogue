using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationInitializer : MonoBehaviour
{
    private ConversationManager conversationManager;
    private DialogueInitializer dialogueInitializer;
    public Dictionary<string, Dialogue[]> dialogues;

    void Start()
    {
        conversationManager = FindObjectOfType<ConversationManager>();
        dialogueInitializer = FindObjectOfType<DialogueInitializer>();
        ConversationList.InitializeConversations();
    }

    public void TriggerConversation(ActorList actor)
    {
        if (actor == ActorList.BLOCKING_GUARD)
        {
            conversationManager.StartConversation(ConversationList.BLOCKING_GUARD);
        } else if (actor == ActorList.DETECTIVE)
        {
            if (Flags.FIRST_MET_DETECTIVE_CORONER)
            {
                conversationManager.StartConversation(ConversationList.DETECTIVE);
            } else
            {
                dialogueInitializer.TriggerDialogue(DialogueKeys.DETECTIVE_CORONER_INTRO, false);
            }
            
        }
        else if (actor == ActorList.CORONER)
        {
            if (Flags.FIRST_MET_DETECTIVE_CORONER)
            {
                conversationManager.StartConversation(ConversationList.CORONER);
            }
            else
            {
                dialogueInitializer.TriggerDialogue(DialogueKeys.DETECTIVE_CORONER_INTRO, false);
            }
        }
    }
}
