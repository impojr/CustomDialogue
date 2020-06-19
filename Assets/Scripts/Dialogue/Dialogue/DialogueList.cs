using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialogueList
{
    public static Dictionary<string, Dialogue> dialogues;

    public static void InitializeDialogueDictionary()
    {
        dialogues = new Dictionary<string, Dialogue>();

        Dialogue dialogue2 = new Dialogue();
        DialogueUI[] dialogueUI2 = new DialogueUI[3];
        dialogueUI2[0] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Show me your ID!", Emotion.IDLE);
        dialogueUI2[1] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Use the inventory selector on the right of our conversation tab.", Emotion.IDLE);
        dialogueUI2[2] = DialogueUI.Create(Actor.BLOCKING_GUARD, "And select your ID to show me.", Emotion.IDLE);
        dialogue2.EventAfterID = AfterEventList.NONE;
        dialogue2.dialogue = dialogueUI2;
        dialogues.Add(DialogueKeys.GUARD_HOW_TO_SHOW_ID, dialogue2);

        Dialogue dialogue3 = new Dialogue();
        DialogueUI[] dialogueUI3 = new DialogueUI[2];
        dialogueUI3[0] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Ah, perfect. That's what I needed to see.", Emotion.IDLE);
        dialogueUI3[1] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Go right on through, the detective is back there already.", Emotion.IDLE);
        dialogue3.EventAfterID = AfterEventList.SHOW_ID_TO_GUARD;
        dialogue3.dialogue = dialogueUI3;
        dialogues.Add(DialogueKeys.GUARD_SHOWING_ID, dialogue3);

        Dialogue dialogue4 = new Dialogue();
        DialogueUI[] dialogueUI4 = new DialogueUI[3];
        dialogueUI4[0] = DialogueUI.Create(Actor.BLOCKING_GUARD, "You've already shown me this.", Emotion.IDLE);
        dialogueUI4[1] = DialogueUI.Create(Actor.BLOCKING_GUARD, "I'm sure you're still the same person.", Emotion.IDLE);
        dialogueUI4[2] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Go right on through, the detective is back there already.", Emotion.IDLE);
        dialogue4.EventAfterID = AfterEventList.NONE;
        dialogue4.dialogue = dialogueUI4;
        dialogues.Add(DialogueKeys.SHOWN_ID_TO_GUARD, dialogue4);

        Dialogue dialogue5 = new Dialogue();
        DialogueUI[] dialogueUI5 = new DialogueUI[3];
        dialogueUI5[0] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Stop!", Emotion.IDLE);
        dialogueUI5[1] = DialogueUI.Create(Actor.BLOCKING_GUARD, "You need to show me your ID!", Emotion.SAD);
        dialogueUI5[2] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Come over here and show it to me!", Emotion.HAPPY);
        dialogue5.EventAfterID = AfterEventList.MOVE_BACK_BEHIND_GUARD;
        dialogue5.dialogue = dialogueUI5;
        dialogues.Add(DialogueKeys.WALK_PAST_GUARD_WITHOUT_SHOWING_ID, dialogue5);

        Dialogue dialogue6 = new Dialogue();
        DialogueUI[] dialogueUI6 = new DialogueUI[2];
        dialogueUI6[0] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Not much odd stuff. There was a crazy homeless man trying to get in here before.", Emotion.IDLE);
        dialogueUI6[1] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Thankfully there's an officer stopping him from the front, else I'd have to make conversation with another person I don't want to speak to.", Emotion.IDLE);
        dialogue6.EventAfterID = AfterEventList.NONE;
        dialogue6.dialogue = dialogueUI6;
        dialogues.Add(DialogueKeys.GUARD_SEEN_ANYTHING_ODD, dialogue6);

        Dialogue dialogue7 = new Dialogue();
        DialogueUI[] dialogueUI7 = new DialogueUI[2];
        dialogueUI7[0] = DialogueUI.Create(Actor.COP_AT_FRONT_OF_HOUSE, "Lalalala", Emotion.IDLE);
        dialogueUI7[1] = DialogueUI.Create(Actor.HOMELESS_MAN, "Tetetetete", Emotion.IDLE);
        dialogue7.EventAfterID = AfterEventList.NONE;
        dialogue7.dialogue = dialogueUI7;
        dialogues.Add(DialogueKeys.HOMELESS_MAN_CONVERSATION, dialogue7);
    }
}
