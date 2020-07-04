using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInitializer : Singleton<DialogueInitializer>
{
    private DialogueManager dialogueManager;
    public Dictionary<string, Dialogue[]> dialogues;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = DialogueManager.Instance;
        DialogueDatabase.InitializeDialogueDictionary();
    }

    public void TriggerDialogue(string key, bool returnToConversation)
    {
        Dialogue dialogue = DialogueDatabase.dialogues[key];

        dialogueManager.StartDialogue(dialogue, returnToConversation);
    }

    public void TriggerDialogue(Actor actor, Item item)
    {
        if (item == ItemDatabase.GetItem(ItemId.ID))
        {
            if (actor == ActorDatabase.BLOCKING_GUARD)
            {
                if (FlagManager.Instance.SHOWN_GUARD_ID)
                {
                    TriggerDialogue(DialogueKeys.SHOWN_ID_TO_GUARD, true);
                } else
                {
                    TriggerDialogue(DialogueKeys.GUARD_SHOWING_ID, true);
                }
            }
            return;
        } 

        if (item == ItemDatabase.GetItem(ItemId.Box))
        {
            if (actor == ActorDatabase.BLOCKING_GUARD)
            {
                TriggerDialogue(DialogueKeys.WHAT_A_LOVELY_BOX, true);
            }
            return;
        }
    }
}
