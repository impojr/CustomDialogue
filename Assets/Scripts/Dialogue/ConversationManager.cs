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
    private DialogueInitializer dialogueInitializer;
    private Conversation lastConversation;

    void Awake()
    {
        dialogueInitializer = FindObjectOfType<DialogueInitializer>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        canvasOpen = false;
    }

    void Update()
    {
        if (canvasOpen && Input.GetKeyDown(KeyCode.Backspace)) {
            EndConversation();
        }
    }

    public void StartConversation(Conversation conversation)
    {
        playerMovement.canMove = false;
        animator.SetBool("IsOpen", true);
        speaker.sprite = conversation.sprite;
        canvasOpen = true;

        talkItem1.GetComponentInChildren<TextMeshProUGUI>().text = conversation.textbox1;

        if (conversation.textbox2 != "")
        {
            talkItem2.gameObject.SetActive(true);
            talkItem2.GetComponentInChildren<TextMeshProUGUI>().text = conversation.textbox2;
        }
        else
        {
            talkItem2.gameObject.SetActive(false);
        }

        if (conversation.textbox3 != "")
        {
            talkItem3.gameObject.SetActive(true);
            talkItem3.GetComponentInChildren<TextMeshProUGUI>().text = conversation.textbox3;
        }
        else
        {
            talkItem3.gameObject.SetActive(false);
        }

        if (conversation.textbox4 != "")
        {
            talkItem4.gameObject.SetActive(true);
            talkItem4.GetComponentInChildren<TextMeshProUGUI>().text = conversation.textbox4;
        }
        else
        {
            talkItem4.gameObject.SetActive(false);
        }

        lastConversation = conversation;
        //Cursor.lockState = CursorLockMode.None;
    }

    public void EndConversation()
    {
        animator.SetBool("IsOpen", false);
        canvasOpen = false;
        playerMovement.canMove = true;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    public void TriggerDialogue(TextMeshProUGUI text)
    {
        EndConversation(); 
        dialogueInitializer.TriggerDialogue(text.text, true);
    }

    public void ReturnToConversation()
    {
        StartConversation(lastConversation);
    }
}
