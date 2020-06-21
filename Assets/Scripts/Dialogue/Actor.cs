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

    public static Actor COP_AT_FRONT_OF_HOUSE = new Actor
    {
        id = ActorList.COP_AT_FRONT_OF_HOUSE,
        name = "Cop",
        emotions = EmotionSprites.Create("Images/Actors/CopAtFrontOfHouse")
    };

    public static Actor HOMELESS_MAN = new Actor
    {
        id = ActorList.HOMELESS_MAN,
        name = "Homeless Man",
        emotions = EmotionSprites.Create("Images/Actors/HomelessMan")
    };
}

public enum ActorList
{
    BLOCKING_GUARD,
    COP_AT_FRONT_OF_HOUSE,
    HOMELESS_MAN,
    DETECTIVE,
    CORONER
}