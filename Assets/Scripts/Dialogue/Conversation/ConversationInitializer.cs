using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationInitializer : Singleton<ConversationInitializer>
{
    private ConversationManager conversationManager;
    private DialogueInitializer dialogueInitializer;
    public Dictionary<string, Dialogue[]> dialogues;

    void Start()
    {
        conversationManager = ConversationManager.Instance;
        dialogueInitializer = DialogueInitializer.Instance;
        ConversationDatabase.InitializeConversations();
    }

    public void TriggerConversation(ActorList actor)
    {
        if (actor == ActorList.BLOCKING_GUARD)
        {
            conversationManager.StartConversation(ConversationDatabase.BLOCKING_GUARD);
        } else if (actor == ActorList.DETECTIVE)
        {
            if (FlagManager.Instance.FIRST_MET_DETECTIVE_CORONER)
            {
                conversationManager.StartConversation(ConversationDatabase.DETECTIVE);
            } else
            {
                dialogueInitializer.TriggerDialogue(DialogueKeys.DETECTIVE_CORONER_INTRO, false);
            }
            
        }
        else if (actor == ActorList.CORONER)
        {
            if (FlagManager.Instance.FIRST_MET_DETECTIVE_CORONER)
            {
                conversationManager.StartConversation(ConversationDatabase.CORONER);
            }
            else
            {
                dialogueInitializer.TriggerDialogue(DialogueKeys.DETECTIVE_CORONER_INTRO, false);
            }
        }
    }
}
