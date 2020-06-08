using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public string sentence;
    public Sprite image;

    public static Dialogue Create (Actor actor, string sentence, Emotion emotion)
    {
        Sprite sprite = null;

        if (emotion == Emotion.IDLE)
        {
            sprite = actor.emotions.Idle;
        } else if (emotion == Emotion.ANGRY)
        {
            sprite = actor.emotions.Angry;
        }
        else if (emotion == Emotion.HAPPY)
        {
            sprite = actor.emotions.Happy;
        }
        else if (emotion == Emotion.SAD)
        {
            sprite = actor.emotions.Sad;
        }
        else if (emotion == Emotion.SURPRISED)
        {
            sprite = actor.emotions.Surprised;
        }

        return new Dialogue
        {
            name = actor.name,
            sentence = sentence,
            image = sprite
        };
    }
}