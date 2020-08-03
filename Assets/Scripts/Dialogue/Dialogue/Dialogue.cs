using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public List<DialogueUI> dialogue;
    public AfterEventList EventAfterID;
}

public class DialogueUI
{
    public string name;
    public string sentence;
    public Sprite image;

    public DialogueUI(Actor actor, string sentence, Emotion emotion)
    {
        name = actor.FirstName;
        this.sentence = sentence;
        image = EmotionHelper.GetSpriteOfEmotion(emotion, actor);
    }
}