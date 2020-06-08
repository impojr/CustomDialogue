using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConversationList
{
    public static Conversation BLOCKING_GUARD;

    public static void InitializeConversations()
    {
        BLOCKING_GUARD = new Conversation
        {
            actor = Actor.BLOCKING_GUARD,
            emotion = Emotion.IDLE,
            textboxes = new TextBox[] { new TextBox { text = DialogueKeys.HOW_TO_SHOW_ID, visited = false }, null, null, null }
        };
    }
}
