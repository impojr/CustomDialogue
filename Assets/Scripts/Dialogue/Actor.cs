using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    public ActorList id;
    public string name;
    public EmotionSprites emotions;

    public static Actor RECEIVE_ITEM = new Actor
    {
        id = ActorList.RECEIVE_ITEM,
        name = " ",
        emotions = EmotionSprites.Create("Images/Actors/BlockingGuard")
    };

    public static Actor PLAYER = new Actor
    {
        id = ActorList.PLAYER,
        name = "Jana",
        emotions = EmotionSprites.Create("Images/Actors/Player")
    };

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

    public static Actor DETECTIVE = new Actor
    {
        id = ActorList.DETECTIVE,
        name = "Detective",
        emotions = EmotionSprites.Create("Images/Actors/Detective")
    };

    public static Actor CORONER = new Actor
    {
        id = ActorList.CORONER,
        name = "Coroner",
        emotions = EmotionSprites.Create("Images/Actors/Coroner")
    };
}

public enum ActorList
{
    PLAYER,
    BLOCKING_GUARD,
    COP_AT_FRONT_OF_HOUSE,
    HOMELESS_MAN,
    DETECTIVE,
    RECEIVE_ITEM,
    CORONER
}