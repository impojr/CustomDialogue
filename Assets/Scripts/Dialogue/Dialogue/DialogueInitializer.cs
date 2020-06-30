using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInitializer : MonoBehaviour
{
    private DialogueManager dialogueManager;
    public Dictionary<string, Dialogue[]> dialogues;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        DialogueList.InitializeDialogueDictionary();
    }

    public void TriggerDialogue(string key, bool returnToConversation)
    {
        Dialogue dialogue = DialogueList.dialogues[key];

        dialogueManager.StartDialogue(dialogue, returnToConversation);
    }

    public void TriggerDialogue(Actor actor, Item item)
    {
        if (item == ItemList.ID)
        {
            if (actor == ActorDatabase.BLOCKING_GUARD)
            {
                if (Flags.SHOWN_GUARD_ID)
                {
                    TriggerDialogue(DialogueKeys.SHOWN_ID_TO_GUARD, true);
                } else
                {
                    TriggerDialogue(DialogueKeys.GUARD_SHOWING_ID, true);
                }
            }
        }
    }
}
