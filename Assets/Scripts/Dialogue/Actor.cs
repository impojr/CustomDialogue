using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    public ActorList id;
    public string name;
    public EmotionSprites emotions;

    public static Actor BLOCKING_GUARD = new Actor
    {
        id = ActorList.BLOCKING_GUARD,
        name = "Jeff",
        emotions = EmotionSprites.Create("Images/Actors/BlockingGuard")
    };
}

public enum ActorList
{
    BLOCKING_GUARD
}

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