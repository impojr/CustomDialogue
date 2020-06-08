using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    public ActorList id;
    public string name;
    public Sprite image;

    public static Actor BLOCKING_GUARD = new Actor
    {
        id = ActorList.BLOCKING_GUARD,
        name = "Jeff",
        image = Resources.Load<Sprite>("Images/Actors/BlockingGuard/Idle")
    };
}

public enum ActorList
{
    BLOCKING_GUARD
}