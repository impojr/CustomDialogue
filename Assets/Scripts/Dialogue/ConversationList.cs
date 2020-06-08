using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConversationList
{
    public static Conversation BLOCKING_GUARD = new Conversation
    {
        name = "Guard",
        //sprite =
        textboxes = new TextBox[] { new TextBox { text = DialogueKeys.SHOW_ID_TO_GUARD, visited = false }, null, null, null }
    };
}
