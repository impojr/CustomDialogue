using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionSprites
{
    public Sprite Idle;
    public Sprite Happy;
    public Sprite Surprised;
    public Sprite Sad;
    public Sprite Angry;

    public static EmotionSprites Create(string resourceLocation)
    {
        return new EmotionSprites
        {
            Idle = Resources.Load<Sprite>(resourceLocation + "/Idle"),
            Happy = Resources.Load<Sprite>(resourceLocation + "/Happy"),
            Surprised = Resources.Load<Sprite>(resourceLocation + "/Surprised"),
            Sad = Resources.Load<Sprite>(resourceLocation + "/Sad"),
            Angry = Resources.Load<Sprite>(resourceLocation + "/Angry")
        };
    }
}

public enum Emotion
{
    IDLE,
    HAPPY,
    SURPRISED,
    SAD,
    ANGRY
}

public static class EmotionHelper
{
    public static Sprite GetSpriteOfEmotion(Emotion emotion, Actor actor)
    {
        Sprite sprite = null;

        if (emotion == Emotion.IDLE)
        {
            sprite = actor.Emotions.Idle;
        }
        else if (emotion == Emotion.ANGRY)
        {
            sprite = actor.Emotions.Angry;
        }
        else if (emotion == Emotion.HAPPY)
        {
            sprite = actor.Emotions.Happy;
        }
        else if (emotion == Emotion.SAD)
        {
            sprite = actor.Emotions.Sad;
        }
        else if (emotion == Emotion.SURPRISED)
        {
            sprite = actor.Emotions.Surprised;
        }

        return sprite;
    }
}