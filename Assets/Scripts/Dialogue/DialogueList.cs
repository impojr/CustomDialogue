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
        dialogue[0] = Dialogue.Create(Actor.BLOCKING_GUARD, "Hey!", Emotion.IDLE);
        dialogue[1] = Dialogue.Create(Actor.BLOCKING_GUARD, "You need to show me your ID.", Emotion.IDLE);
        dialogue[2] = Dialogue.Create(Actor.BLOCKING_GUARD, "Please come here and show me your ID.", Emotion.IDLE);
        dialogues.Add("TEST", dialogue);

        Dialogue[] dialogue2 = new Dialogue[3];
        dialogue2[0] = Dialogue.Create(Actor.BLOCKING_GUARD, "Show me your ID!", Emotion.IDLE);
        dialogue2[1] = Dialogue.Create(Actor.BLOCKING_GUARD, "Use the inventory selector on the right of our conversation tab.", Emotion.IDLE);
        dialogue2[2] = Dialogue.Create(Actor.BLOCKING_GUARD, "And select your ID to show me.", Emotion.IDLE);
        dialogues.Add(DialogueKeys.SHOW_ID_TO_GUARD, dialogue2);

        Dialogue[] dialogue3 = new Dialogue[2];
        dialogue3[0] = Dialogue.Create(Actor.BLOCKING_GUARD, "Ah, perfect. That's what I needed to see.", Emotion.IDLE);
        dialogue3[1] = Dialogue.Create(Actor.BLOCKING_GUARD, "Go right on through, the detective is back there already.", Emotion.IDLE);
        dialogues.Add(DialogueKeys.SHOWING_ID_TO_GUARD, dialogue3);
    }
}
