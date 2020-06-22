using System;
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
        DetectiveCoronerIntro();
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

    private static void DetectiveCoronerIntro()
    {
        Dialogue dialogue = new Dialogue();
        DialogueUI[] dialogueUI = new DialogueUI[13];
        dialogueUI[0] = DialogueUI.Create(Actor.DETECTIVE, "That's pretty damning.", Emotion.IDLE);
        dialogueUI[1] = DialogueUI.Create(Actor.CORONER, "Yes, I agree.", Emotion.IDLE);
        dialogueUI[2] = DialogueUI.Create(Actor.DETECTIVE, "Oh - hi Jana. I've just been talking to the coroner. We think this is a fairly open and shut case.", Emotion.IDLE);
        dialogueUI[3] = DialogueUI.Create(Actor.CORONER, "Yes. Here, have a copy of the preliminary autopsy report.", Emotion.IDLE);
        dialogueUI[4] = DialogueUI.Create(Actor.RECEIVE_ITEM, "Recieved a copy of the preliminary autopsy report.", Emotion.IDLE);
        //todo add item to inventory, autopsy report
        dialogueUI[5] = DialogueUI.Create(Actor.CORONER, "The victim was stabbed sometime last night. That seems to be the cause of death.", Emotion.IDLE);
        dialogueUI[6] = DialogueUI.Create(Actor.DETECTIVE, "Yes. And the only two people here last night were the victim, Dee Ceest and her boss, Wissen.", Emotion.IDLE);
        dialogueUI[7] = DialogueUI.Create(Actor.DETECTIVE, "Oh. Well that sounds easy: her boss did it.", Emotion.IDLE); //todo change to player
        dialogueUI[8] = DialogueUI.Create(Actor.DETECTIVE, "Remember what I told you about making assumptions?", Emotion.IDLE);
        dialogueUI[9] = DialogueUI.Create(Actor.DETECTIVE, "Though, in this case I'd agree with you.", Emotion.IDLE);
        dialogueUI[10] = DialogueUI.Create(Actor.DETECTIVE, "However, this looks like a good time for you to take charge in this investigation.", Emotion.IDLE);
        dialogueUI[11] = DialogueUI.Create(Actor.DETECTIVE, "You sure?! It will be my first time taking the lead.", Emotion.IDLE); //todo change to player
        dialogueUI[12] = DialogueUI.Create(Actor.DETECTIVE, "I'm sure. We need to go over the scene, do some questioning, and connect the dots. You have the reigns.", Emotion.IDLE); //todo change to player
        dialogue.EventAfterID = AfterEventList.FIRST_MET_DETECTIVE_CORONER;
        dialogue.dialogue = dialogueUI;
        dialogues.Add(DialogueKeys.DETECTIVE_CORONER_INTRO, dialogue);
    }
}
