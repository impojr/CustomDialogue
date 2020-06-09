using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    private DialogueInitializer dialogueInitializer;
    private PlayerMovement playerMovement;

    public Transform positionToMoveTo;

    void Awake()
    {
        dialogueInitializer = FindObjectOfType<DialogueInitializer>();
        playerMovement = FindObjectOfType<PlayerMovement>();
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
            StartCoroutine(MovePlayer());
        }
    }

    public IEnumerator MovePlayer()
    {
        playerMovement.DisablePlayerMovement();
        playerMovement.StartWalkingAnim();
        playerMovement.transform.LookAt(positionToMoveTo);

        while (Vector3.Distance(playerMovement.transform.position, positionToMoveTo.position) > 0.1f)
        {
            float step = playerMovement.Velocity * Time.deltaTime; // calculate distance to move
            playerMovement.transform.position = Vector3.MoveTowards(playerMovement.transform.position, positionToMoveTo.position, step);
            yield return new WaitForEndOfFrame();
        }

        playerMovement.StopWalkingAnim();
        playerMovement.EnablePlayerMovement();
    }
}