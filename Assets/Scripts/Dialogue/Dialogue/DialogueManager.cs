using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class DialogueManager : Singleton<DialogueManager>
{
    public Animator animator;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image image;
    public Queue<DialogueUI> sentences;
    public bool canvasOpen;

    private PlayerMovement playerMovement;
    private ConversationManager conversationManager;
    private bool returnToConversation;
    private Camera mainCamera;
    private AfterEventList afterDialogueEvent;
    private bool isTypingSentence;

    void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        conversationManager = ConversationManager.Instance;
        mainCamera = Camera.main;
        sentences = new Queue<DialogueUI>();
        isTypingSentence = false;
    }

    internal void StartDialogue(Dialogue dialogue, bool returnToConversation)
    {
        this.returnToConversation = returnToConversation;
        mainCamera.GetComponent<CinemachineBrain>().enabled = false;
        playerMovement.DisablePlayerMovement();
        animator.SetBool("IsOpen", true);
        canvasOpen = true;
        //Cursor.lockState = CursorLockMode.None;
        sentences.Clear();
        afterDialogueEvent = dialogue.EventAfterID;

        foreach (DialogueUI dialogueUI in dialogue.dialogue)
        {
            sentences.Enqueue(dialogueUI);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (isTypingSentence)
        {
            return;
        }

        if (sentences.Count == 0)
        {
            EndDialogue();
            if (returnToConversation)
            {
                conversationManager.ReturnToConversation();
            }
            return;
        }

        DialogueUI sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (DialogueUI sentence)
    {
        isTypingSentence = true;
        if (sentence.image != null)
        {
            image.sprite = sentence.image;
        }

        if (sentence.name != "")
        {
            nameText.text = sentence.name;
        }

        dialogueText.text = "";
        foreach(char letter in sentence.sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForEndOfFrame();
        }
        isTypingSentence = false;
    }

    private void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        playerMovement.EnablePlayerMovement();
        mainCamera.GetComponent<CinemachineBrain>().enabled = true;
        canvasOpen = false;
        //Cursor.lockState = CursorLockMode.Locked;
        if (afterDialogueEvent != AfterEventList.NONE)
        {
            EventManager.Instance.TriggerEvent(afterDialogueEvent);
        }
    }
}
