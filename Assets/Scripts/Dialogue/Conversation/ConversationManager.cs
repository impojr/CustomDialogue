using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class ConversationManager : MonoBehaviour
{
    public Animator animator;
    public bool canvasOpen;
    public Image speaker;
    public TextMeshProUGUI speakerName;

    public Button[] talkItems;
    public Image inventoryItemImage;
    public TextMeshProUGUI inventoryItemName;
    public Button inventoryLeft;
    public Button inventoryRight;

    private PlayerMovement playerMovement;
    private DialogueInitializer dialogueInitializer;
    private Conversation lastConversation;
    private int inventoryIndex;
    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
        dialogueInitializer = FindObjectOfType<DialogueInitializer>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        canvasOpen = false;

        inventoryIndex = 0;
        UpdateInventoryItem();
        UpdateInventoryButtons();
    }

    void Update()
    {
        if (canvasOpen && Input.GetKeyDown(KeyCode.Backspace)) {
            EndConversation();
        }
    }

    public void StartConversation(Conversation conversation)
    {
        mainCamera.GetComponent<CinemachineBrain>().enabled = false;
        playerMovement.DisablePlayerMovement();
        animator.SetBool("IsOpen", true);
        speaker.sprite = EmotionHelper.GetSpriteOfEmotion(conversation.emotion, conversation.actor);
        speakerName.text = conversation.actor.name;
        UpdateInventoryButtons();
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
        playerMovement.EnablePlayerMovement();
        mainCamera.GetComponent<CinemachineBrain>().enabled = true;
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

    public void MoveInventoryLeft()
    {
        if (inventoryIndex == 0)
        {
            inventoryIndex = Inventory.items.Count - 1;
        } else
        {
            inventoryIndex--;
        }

        UpdateInventoryItem();
    }

    public void MoveInventoryRight()
    {
        if (inventoryIndex == Inventory.items.Count - 1)
        {
            inventoryIndex = 0;
        }
        else
        {
            inventoryIndex++;
        }

        UpdateInventoryItem();
    }

    public void UpdateInventoryItem()
    {
        inventoryItemImage.sprite = Inventory.items[inventoryIndex].image;
        inventoryItemName.text = Inventory.items[inventoryIndex].name;
    }

    public void UpdateInventoryButtons()
    {
        if (Inventory.items.Count < 2)
        {
            inventoryLeft.interactable = false;
            inventoryRight.interactable = false;
        } else
        {
            inventoryLeft.interactable = true;
            inventoryRight.interactable = true;
        }
    }

    public void PresentItem()
    {
        Item itemToPresent = Inventory.items[inventoryIndex];

        EndConversation();
        dialogueInitializer.TriggerDialogue(lastConversation.actor, itemToPresent);
    }
}
