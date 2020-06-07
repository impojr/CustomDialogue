using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Image image;
    public Queue<Dialogue> sentences;

    private PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        sentences = new Queue<Dialogue>();
    }

    internal void StartDialogue(Dialogue[] dialogues)
    {
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
        //Cursor.lockState = CursorLockMode.Locked;
    }
}
