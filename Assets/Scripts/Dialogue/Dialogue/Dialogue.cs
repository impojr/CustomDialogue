using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public DialogueUI[] dialogue;
    public AfterEventList EventAfterID;
}

public class DialogueUI
{
    public string name;
    public string sentence;
    public Sprite image;

    public static DialogueUI Create(Actor actor, string sentence, Emotion emotion)
    {
        return new DialogueUI
        {
            name = actor.name,
            sentence = sentence,
            image = EmotionHelper.GetSpriteOfEmotion(emotion, actor)
        };
    }
}