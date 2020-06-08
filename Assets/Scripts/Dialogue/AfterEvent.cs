using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AfterEvent
{
    public static void TriggerEvent(string eventID)
    {
        if (eventID == AfterEventID.SHOW_ID_TO_GUARD)
        {
            Flags.SHOWN_GUARD_ID = true;
        }
    }
}

public static class AfterEventID
{
    public static string SHOW_ID_TO_GUARD = "SHOW_ID_TO_GUARD";
    public static string NONE = "";
}