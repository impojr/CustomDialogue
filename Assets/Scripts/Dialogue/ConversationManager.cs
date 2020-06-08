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

    public Button[] talkItems;

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

        for (int i = 0; i < talkItems.Length; i++)
        {
            if (conversation.textboxes[i] != null)
            {
                talkItems[i].gameObject.SetActive(true);
                talkItems[i].GetComponentInChildren<TextMeshProUGUI>().text = conversation.textboxes[i].text;
                if (conversation.textboxes[i].visited)
                {
                    talkItems[i].GetComponent<Image>().color = Color.grey;
                }
            }
            else
            {
                talkItems[i].gameObject.SetActive(false);
            }
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
        lastConversation.SetAsVisited(text.text);
        dialogueInitializer.TriggerDialogue(text.text, true);
    }

    public void ReturnToConversation()
    {
        StartConversation(lastConversation);
    }
}
