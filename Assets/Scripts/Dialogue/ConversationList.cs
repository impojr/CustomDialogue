using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConversationList
{
    public static Conversation BLOCKING_GUARD = new Conversation
    {
        name = "Guard",
        //sprite =
        textbox1 = DialogueKeys.SHOW_ID_TO_GUARD,
        textbox2 = "",
        textbox3 = "",
        textbox4 = ""
    };
}
