using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInitializer : MonoBehaviour
{
    private DialogueManager dialogueManager;
    public Dictionary<string, Dialogue[]> dialogues;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        DialogueList.InitializeDialogueDictionary();
    }

    public void TriggerDialogue(string key, bool returnToConversation)
    {
        Dialogue[] dialogue = DialogueList.dialogues[key];

        dialogueManager.StartDialogue(dialogue, returnToConversation);
    }
}
