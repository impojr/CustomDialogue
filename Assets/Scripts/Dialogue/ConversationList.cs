using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConversationList
{
    public static Conversation BLOCKING_GUARD = new Conversation
    {
        name = "Guard",
        //sprite =
        textbox1 = new TextBox { text = DialogueKeys.SHOW_ID_TO_GUARD, visited = false },
        textbox2 = null,
        textbox3 = null,
        textbox4 = null
    };
}
