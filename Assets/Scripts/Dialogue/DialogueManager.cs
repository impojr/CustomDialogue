using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image image;
    public Queue<Dialogue> sentences;

    private PlayerMovement playerMovement;
    private ConversationManager conversationManager;
    private bool returnToConversation;
    private Camera mainCamera;

    void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        conversationManager = FindObjectOfType<ConversationManager>();
        mainCamera = Camera.main;
        sentences = new Queue<Dialogue>();
    }

    internal void StartDialogue(Dialogue[] dialogues, bool returnToConversation)
    {
        this.returnToConversation = returnToConversation;
        mainCamera.GetComponent<CinemachineBrain>().enabled = false;
        playerMovement.canMove = false;
        animator.SetBool("IsOpen", true);
        //Cursor.lockState = CursorLockMode.None;
        sentences.Clear();

        foreach (Dialogue dialogue in dialogues)
        {
            sentences.Enqueue(dialogue);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            if (returnToConversation)
            {
                conversationManager.ReturnToConversation();
            }
            return;
        }

        Dialogue sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (Dialogue sentence)
    {
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
    }

    private void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        playerMovement.canMove = true;
        mainCamera.GetComponent<CinemachineBrain>().enabled = true;
        //Cursor.lockState = CursorLockMode.Locked;
    }
}
