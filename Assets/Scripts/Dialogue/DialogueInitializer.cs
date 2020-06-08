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
        InitializeDialogueDictionary();
    }

    private void InitializeDialogueDictionary()
    {
        dialogues = new Dictionary<string, Dialogue[]>();
        Dialogue[] dialogue = new Dialogue[3];
        dialogue[0] = Dialogue.Create("Jeff", "Hey!");
        dialogue[1] = Dialogue.Create("Jeff", "You need to show me your ID.");
        dialogue[2] = Dialogue.Create("Jeff", "Please come here and show me your ID.");
        dialogues.Add("TEST", dialogue);

        Dialogue[] dialogue2 = new Dialogue[3];
        dialogue2[0] = Dialogue.Create("Jeff", "Show me your ID!");
        dialogue2[1] = Dialogue.Create("Jeff", "Use the inventory selector on the right of our conversation tab.");
        dialogue2[2] = Dialogue.Create("Jeff", "And select your ID to show me.");
        dialogues.Add(DialogueKeys.SHOW_ID_TO_GUARD, dialogue2);
    }

    public void TriggerDialogue(string key, bool returnToConversation)
    {
        Dialogue[] dialogue = dialogues[key];

        dialogueManager.StartDialogue(dialogue, returnToConversation);
    }
}
