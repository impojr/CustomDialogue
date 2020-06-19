using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DialogueList
{
    public static Dictionary<string, Dialogue> dialogues;

    public static void InitializeDialogueDictionary()
    {
        dialogues = new Dictionary<string, Dialogue>();
        HowToShowGuardIdDialogue();
        ShowingGuardIdDialogue();
        ShownIdToGuardDialogue();
        WalkPastGuardWithoutShowingIdDialogue();
        GuardSeenAnythingOddDialogue();
        HomelessManConversationDialogue();
    }

    private static void HowToShowGuardIdDialogue()
    {
        Dialogue dialogue = new Dialogue();
        DialogueUI[] dialogueUI = new DialogueUI[3];
        dialogueUI[0] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Show me your ID!", Emotion.IDLE);
        dialogueUI[1] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Use the inventory selector on the right of our conversation tab.", Emotion.IDLE);
        dialogueUI[2] = DialogueUI.Create(Actor.BLOCKING_GUARD, "And select your ID to show me.", Emotion.IDLE);
        dialogue.EventAfterID = AfterEventList.NONE;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.GUARD_HOW_TO_SHOW_ID, dialogue);
    }

    private static void ShowingGuardIdDialogue()
    {
        Dialogue dialogue = new Dialogue();
        DialogueUI[] dialogueUI = new DialogueUI[2];
        dialogueUI[0] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Ah, perfect. That's what I needed to see.", Emotion.IDLE);
        dialogueUI[1] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Go right on through, the detective is back there already.", Emotion.IDLE);
        dialogue.EventAfterID = AfterEventList.SHOW_ID_TO_GUARD;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.GUARD_SHOWING_ID, dialogue);
    }

    private static void ShownIdToGuardDialogue()
    {
        Dialogue dialogue = new Dialogue();
        DialogueUI[] dialogueUI = new DialogueUI[3];
        dialogueUI[0] = DialogueUI.Create(Actor.BLOCKING_GUARD, "You've already shown me this.", Emotion.IDLE);
        dialogueUI[1] = DialogueUI.Create(Actor.BLOCKING_GUARD, "I'm sure you're still the same person.", Emotion.IDLE);
        dialogueUI[2] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Go right on through, the detective is back there already.", Emotion.IDLE);
        dialogue.EventAfterID = AfterEventList.NONE;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.SHOWN_ID_TO_GUARD, dialogue);
    }

    private static void WalkPastGuardWithoutShowingIdDialogue()
    {
        Dialogue dialogue = new Dialogue();
        DialogueUI[] dialogueUI = new DialogueUI[3];
        dialogueUI[0] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Stop!", Emotion.IDLE);
        dialogueUI[1] = DialogueUI.Create(Actor.BLOCKING_GUARD, "You need to show me your ID!", Emotion.SAD);
        dialogueUI[2] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Come over here and show it to me!", Emotion.HAPPY);
        dialogue.EventAfterID = AfterEventList.MOVE_BACK_BEHIND_GUARD;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.WALK_PAST_GUARD_WITHOUT_SHOWING_ID, dialogue);
    }

    private static void GuardSeenAnythingOddDialogue()
    {
        Dialogue dialogue = new Dialogue();
        DialogueUI[] dialogueUI = new DialogueUI[2];
        dialogueUI[0] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Not much odd stuff. There was a crazy homeless man trying to get in here before.", Emotion.IDLE);
        dialogueUI[1] = DialogueUI.Create(Actor.BLOCKING_GUARD, "Thankfully there's an officer stopping him from the front, else I'd have to make conversation with another person I don't want to speak to.", Emotion.IDLE);
        dialogue.EventAfterID = AfterEventList.NONE;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.GUARD_SEEN_ANYTHING_ODD, dialogue);
    }

    private static void HomelessManConversationDialogue()
    {
        Dialogue dialogue = new Dialogue();
        DialogueUI[] dialogueUI = new DialogueUI[2];
        dialogueUI[0] = DialogueUI.Create(Actor.COP_AT_FRONT_OF_HOUSE, "Lalalala", Emotion.IDLE);
        dialogueUI[1] = DialogueUI.Create(Actor.HOMELESS_MAN, "Tetetetete", Emotion.IDLE);
        dialogue.EventAfterID = AfterEventList.NONE;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.HOMELESS_MAN_CONVERSATION, dialogue);
    }
}
