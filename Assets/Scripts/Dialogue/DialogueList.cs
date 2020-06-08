using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialogueList
{
    public static Dictionary<string, Dialogue[]> dialogues;

    public static void InitializeDialogueDictionary()
    {
        dialogues = new Dictionary<string, Dialogue[]>();

        Dialogue[] dialogue = new Dialogue[3];
        dialogue[0] = Dialogue.Create(Actor.BLOCKING_GUARD, "Hey!");
        dialogue[1] = Dialogue.Create(Actor.BLOCKING_GUARD, "You need to show me your ID.");
        dialogue[2] = Dialogue.Create(Actor.BLOCKING_GUARD, "Please come here and show me your ID.");
        dialogues.Add("TEST", dialogue);

        Dialogue[] dialogue2 = new Dialogue[3];
        dialogue2[0] = Dialogue.Create(Actor.BLOCKING_GUARD, "Show me your ID!");
        dialogue2[1] = Dialogue.Create(Actor.BLOCKING_GUARD, "Use the inventory selector on the right of our conversation tab.");
        dialogue2[2] = Dialogue.Create(Actor.BLOCKING_GUARD, "And select your ID to show me.");
        dialogues.Add(DialogueKeys.SHOW_ID_TO_GUARD, dialogue2);
    }
}
