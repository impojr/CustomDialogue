using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterEvent : MonoBehaviour
{
    public void TriggerEvent(string eventID)
    {
        if (eventID == AfterEventID.SHOW_ID_TO_GUARD)
        {
            Flags.SHOWN_GUARD_ID = true;
        }
    }
}