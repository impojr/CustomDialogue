using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConversationList
{
    public static Conversation BLOCKING_GUARD;
    public static Conversation DETECTIVE;
    public static Conversation CORONER;

    public static void InitializeConversations()
    {
        BLOCKING_GUARD = new Conversation
        {
            actor = Actor.BLOCKING_GUARD,
            emotion = Emotion.IDLE,
            textboxes = new TextBox[] { new TextBox(DialogueKeys.GUARD_HOW_TO_SHOW_ID), null, null, null }
        };

        DETECTIVE = new Conversation
        {
            actor = Actor.DETECTIVE,
            emotion = Emotion.IDLE,
            textboxes = new TextBox[] { new TextBox(DialogueKeys.GUARD_HOW_TO_SHOW_ID), null, null, null }
        };

        CORONER = new Conversation
        {
            actor = Actor.CORONER,
            emotion = Emotion.IDLE,
            textboxes = new TextBox[] { new TextBox(DialogueKeys.GUARD_HOW_TO_SHOW_ID), null, null, null }
        };
    }
}
