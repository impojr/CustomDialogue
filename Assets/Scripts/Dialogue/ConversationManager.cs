using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{
    public Animator animator;
    public bool canvasOpen;
    public Image speaker;

    public Button talkItem1;
    public Button talkItem2;
    public Button talkItem3;
    public Button talkItem4;

    private PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        canvasOpen = false;
    }

    void Update()
    {
        if (canvasOpen && Input.GetKeyDown(KeyCode.Backspace)) {
            EndConversation();
        }
    }

    public void StartConversation()
    {
        playerMovement.canMove = false;
        animator.SetBool("IsOpen", true);
        //speaker.sprite = 
        canvasOpen = true;
        //Cursor.lockState = CursorLockMode.None;
    }

    public void EndConversation()
    {
        animator.SetBool("IsOpen", false);
        canvasOpen = false;
        playerMovement.canMove = true;
        //Cursor.lockState = CursorLockMode.Locked;
    }
}
