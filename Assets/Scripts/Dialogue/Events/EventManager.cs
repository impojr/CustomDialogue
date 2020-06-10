﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private DialogueInitializer dialogueInitializer;
    private PlayerMovement playerMovement;

    void Awake()
    {
        dialogueInitializer = FindObjectOfType<DialogueInitializer>();
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
        }
    }

    private void SetShownGuardIdToTrue()
    {
        Flags.SHOWN_GUARD_ID = true;
    }

    private void ShowNoIdDialogueIfNoIdShown()
    {
        if (!Flags.SHOWN_GUARD_ID)
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
}