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

    public void StartConversation(Sprite sprite, string button1Text, string button2Text = null, string button3Text = null, string button4Text = null)
    {
        playerMovement.canMove = false;
        animator.SetBool("IsOpen", true);
        speaker.sprite = sprite;
        canvasOpen = true;

        talkItem1.GetComponentInChildren<TextMeshProUGUI>().text = button1Text;

        if (button2Text != null)
        {
            talkItem2.gameObject.SetActive(true);
            talkItem2.GetComponentInChildren<TextMeshProUGUI>().text = button2Text;
        }
        else
        {
            talkItem2.gameObject.SetActive(false);
        }

        if (button3Text != null)
        {
            talkItem3.gameObject.SetActive(true);
            talkItem3.GetComponentInChildren<TextMeshProUGUI>().text = button3Text;
        }
        else
        {
            talkItem3.gameObject.SetActive(false);
        }

        if (button4Text != null)
        {
            talkItem4.gameObject.SetActive(true);
            talkItem4.GetComponentInChildren<TextMeshProUGUI>().text = button4Text;
        }
        else
        {
            talkItem4.gameObject.SetActive(false);
        }

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
        dialogueInitializer.TriggerDialogue(text.text);
    }
}
