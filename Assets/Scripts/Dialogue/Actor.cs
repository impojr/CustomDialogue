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