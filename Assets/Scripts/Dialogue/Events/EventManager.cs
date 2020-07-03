using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    private DialogueInitializer dialogueInitializer;
    private PlayerMovement playerMovement;

    void Awake()
    {
        dialogueInitializer = DialogueInitializer.Instance;
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void TriggerEvent(AfterEventList eventID)
    {
        if (eventID == AfterEventList.SHOW_ID_TO_GUARD)
        {
            SetShownGuardIdToTrue();
        } else if (eventID == AfterEventList.GO_PAST_GUARD_WITHOUT_SHOWING_ID)
        {
            ShowNoIdDialogueIfNoIdShown();
        } else if (eventID == AfterEventList.MOVE_BACK_BEHIND_GUARD)
        {
            StartCoroutine(MovePlayer());
        } else if (eventID == AfterEventList.HOMELESS_MAN_CONVERSATION)
        {
            dialogueInitializer.TriggerDialogue(DialogueKeys.HOMELESS_MAN_CONVERSATION, false);
        } else if (eventID == AfterEventList.FIRST_MET_DETECTIVE_CORONER)
        {
            SetFirstMetFlagAndGetAutopsyReport();
        }
    }

    private void SetShownGuardIdToTrue()
    {
        FlagManager.Instance.SHOWN_GUARD_ID = true;
        ConversationDatabase.BLOCKING_GUARD.textboxes[1] = new TextBox(DialogueKeys.GUARD_SEEN_ANYTHING_ODD);
    }

    private void ShowNoIdDialogueIfNoIdShown()
    {
        if (!FlagManager.Instance.SHOWN_GUARD_ID)
        {
            dialogueInitializer.TriggerDialogue(DialogueKeys.WALK_PAST_GUARD_WITHOUT_SHOWING_ID, false);
        }
    }

    private IEnumerator MovePlayer()
    {
        playerMovement.DisablePlayerMovement();
        playerMovement.StartWalkingAnim();

        GameObject positionToMoveTo = new GameObject();
        positionToMoveTo.transform.position = playerMovement.transform.position - new Vector3(0, 0, 2);
        positionToMoveTo.transform.rotation = playerMovement.transform.rotation;


        playerMovement.transform.LookAt(positionToMoveTo.transform);

        while (Vector3.Distance(playerMovement.transform.position, positionToMoveTo.transform.position) > 0.1f)
        {
            float step = playerMovement.Velocity * Time.deltaTime; // calculate distance to move
            playerMovement.transform.position = Vector3.MoveTowards(playerMovement.transform.position, positionToMoveTo.transform.position, step);
            yield return new WaitForEndOfFrame();
        }

        playerMovement.StopWalkingAnim();
        playerMovement.EnablePlayerMovement();
    }

    private void SetFirstMetFlagAndGetAutopsyReport()
    {
        FlagManager.Instance.FIRST_MET_DETECTIVE_CORONER = true;
        Inventory.Instance.AddItem(ItemDatabase.PRELIM_AUTOPSY);
    }
}