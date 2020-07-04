using System;
using System.Collections.Generic;

public static class DialogueDatabase
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
        DetectiveCoronerIntro();
        BoxInteractDialogue();
        WhatALovelyBoxDialogue();
    }

    private static void HowToShowGuardIdDialogue()
    {
        Dialogue dialogue = new Dialogue();
        List<DialogueUI> dialogueUI = new List<DialogueUI>();
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "Show me your ID!", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "Use the inventory selector on the right of our conversation tab.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "And select your ID to show me.", Emotion.IDLE));
        dialogue.EventAfterID = AfterEventList.NONE;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.GUARD_HOW_TO_SHOW_ID, dialogue);
    }

    private static void ShowingGuardIdDialogue()
    {
        Dialogue dialogue = new Dialogue();
        List<DialogueUI> dialogueUI = new List<DialogueUI>();
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "Ah, perfect. That's what I needed to see.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "Go right on through, the detective is back there already.", Emotion.IDLE));
        dialogue.EventAfterID = AfterEventList.SHOW_ID_TO_GUARD;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.GUARD_SHOWING_ID, dialogue);
    }

    private static void ShownIdToGuardDialogue()
    {
        Dialogue dialogue = new Dialogue();
        List<DialogueUI> dialogueUI = new List<DialogueUI>();
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "You've already shown me this.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "I'm sure you're still the same person.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "Go right on through, the detective is back there already.", Emotion.IDLE));
        dialogue.EventAfterID = AfterEventList.NONE;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.SHOWN_ID_TO_GUARD, dialogue);
    }

    private static void WalkPastGuardWithoutShowingIdDialogue()
    {
        Dialogue dialogue = new Dialogue();
        List<DialogueUI> dialogueUI = new List<DialogueUI>();
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "Stop!", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "You need to show me your ID!", Emotion.SAD));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "Come over here and show it to me!", Emotion.HAPPY));
        dialogue.EventAfterID = AfterEventList.MOVE_BACK_BEHIND_GUARD;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.WALK_PAST_GUARD_WITHOUT_SHOWING_ID, dialogue);
    }

    private static void GuardSeenAnythingOddDialogue()
    {
        Dialogue dialogue = new Dialogue();
        List<DialogueUI> dialogueUI = new List<DialogueUI>();
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "Not much odd stuff. There was a crazy homeless man trying to get in here before.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "Thankfully there's an officer stopping him from the front, else I'd have to make conversation with another person I don't want to speak to.", Emotion.IDLE));
        dialogue.EventAfterID = AfterEventList.NONE;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.GUARD_SEEN_ANYTHING_ODD, dialogue);
    }

    private static void HomelessManConversationDialogue()
    {
        Dialogue dialogue = new Dialogue();
        List<DialogueUI> dialogueUI = new List<DialogueUI>();
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.COP_AT_FRONT_OF_HOUSE, "Lalalala", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.HOMELESS_MAN, "Tetetetete", Emotion.IDLE));
        dialogue.EventAfterID = AfterEventList.NONE;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.HOMELESS_MAN_CONVERSATION, dialogue);
    }

    private static void DetectiveCoronerIntro()
    {
        Dialogue dialogue = new Dialogue();
        List<DialogueUI> dialogueUI = new List<DialogueUI>();
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.DETECTIVE, "That's pretty damning.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.CORONER, "Yes, I agree.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.DETECTIVE, "Oh - hi Jana. I've just been talking to the coroner. We think this is a fairly open and shut case.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.CORONER, "Yes. Here, have a copy of the preliminary autopsy report.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.RECEIVE_ITEM, "Recieved a copy of the preliminary autopsy report.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.CORONER, "The victim was stabbed sometime last night. That seems to be the cause of death.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.DETECTIVE, "Yes. And the only two people here last night were the victim, Dee Ceest and her boss, Wissen.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.PLAYER, "Oh. Well that sounds easy: her boss did it.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.DETECTIVE, "Remember what I told you about making assumptions?", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.DETECTIVE, "Though, in this case I'd agree with you.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.DETECTIVE, "However, this looks like a good time for you to take charge in this investigation.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.PLAYER, "You sure?! It will be my first time taking the lead.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.DETECTIVE, "I'm sure. We need to go over the scene, do some questioning, and connect the dots. You have the reigns.", Emotion.IDLE));
        dialogue.EventAfterID = AfterEventList.FIRST_MET_DETECTIVE_CORONER;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.DETECTIVE_CORONER_INTRO, dialogue);
    }

    private static void BoxInteractDialogue()
    {
        Dialogue dialogue = new Dialogue();
        List<DialogueUI> dialogueUI = new List<DialogueUI>();
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.PLAYER, "Oh look it's a box.", Emotion.IDLE));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.PLAYER, "Yes, I'll take that.", Emotion.HAPPY));
        dialogue.EventAfterID = AfterEventList.NONE;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.ITEM_BOX, dialogue);
    }

    private static void WhatALovelyBoxDialogue()
    {
        Dialogue dialogue = new Dialogue();
        List<DialogueUI> dialogueUI = new List<DialogueUI>();
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "Oh, what a lovely box you have.", Emotion.HAPPY));
        dialogueUI.Add(DialogueUI.Create(ActorDatabase.BLOCKING_GUARD, "... Oh, I'm sorry. That didn't come out right.", Emotion.SURPRISED));
        dialogue.EventAfterID = AfterEventList.NONE;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.WHAT_A_LOVELY_BOX, dialogue);
    }
}
