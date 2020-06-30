using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConversationDatabase
{
    public static Conversation BLOCKING_GUARD;
    public static Conversation DETECTIVE;
    public static Conversation CORONER;

    public static void InitializeConversations()
    {
        BLOCKING_GUARD = new Conversation
        {
            actor = ActorDatabase.BLOCKING_GUARD,
            emotion = Emotion.IDLE,
            textboxes = new TextBox[] { new TextBox(DialogueKeys.GUARD_HOW_TO_SHOW_ID), null, null, null }
        };

        DETECTIVE = new Conversation
        {
            actor = ActorDatabase.DETECTIVE,
            emotion = Emotion.IDLE,
            textboxes = new TextBox[] { new TextBox(DialogueKeys.GUARD_HOW_TO_SHOW_ID), null, null, null }
        };

        CORONER = new Conversation
        {
            actor = ActorDatabase.CORONER,
            emotion = Emotion.IDLE,
            textboxes = new TextBox[] { new TextBox(DialogueKeys.GUARD_HOW_TO_SHOW_ID), null, null, null }
        };
    }
}
