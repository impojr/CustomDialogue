using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private DialogueInitializer dialogueInitializer;

    void Awake()
    {
        dialogueInitializer = FindObjectOfType<DialogueInitializer>();
    }

    public void TriggerEvent(AfterEventList eventID)
    {
        if (eventID == AfterEventList.SHOW_ID_TO_GUARD)
        {
            Flags.SHOWN_GUARD_ID = true;
        } else if (eventID == AfterEventList.GO_PAST_GUARD_WITHOUT_SHOWING_ID)
        {
            if (!Flags.SHOWN_GUARD_ID)
            {
                dialogueInitializer.TriggerDialogue(DialogueKeys.WALK_PAST_GUARD_WITHOUT_SHOWING_ID, false);
            }
        } else if (eventID == AfterEventList.MOVE_BACK_BEHIND_GUARD)
        {

        }
    }
}