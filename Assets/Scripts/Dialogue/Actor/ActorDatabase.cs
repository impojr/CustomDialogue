using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

public static class ActorDatabase
{
    public static Actor RECEIVE_ITEM = new Actor(ActorList.RECEIVE_ITEM, "", "", new EmotionSprites("Images/Actors/BlockingGuard/AHHH"));
    public static Actor PLAYER = new Actor(ActorList.PLAYER, "Jana", "S", new EmotionSprites("Images/Actors/Player"));
    public static Actor BLOCKING_GUARD = new Actor(ActorList.BLOCKING_GUARD, "Jeff", "The Guard", new EmotionSprites("Images/Actors/BlockingGuard"));
    public static Actor COP_AT_FRONT_OF_HOUSE = new Actor(ActorList.COP_AT_FRONT_OF_HOUSE, "Cop", "McCop", new EmotionSprites("Images/Actors/CopAtFrontOfHouse"));
    public static Actor HOMELESS_MAN = new Actor(ActorList.HOMELESS_MAN, "Homeless", "Man", new EmotionSprites("Images/Actors/HomelessMan"));
    public static Actor DETECTIVE = new Actor(ActorList.DETECTIVE, "Detective", "LastName", new EmotionSprites("Images/Actors/Detective"));
    public static Actor CORONER = new Actor(ActorList.CORONER, "Coro", "Nerr", new EmotionSprites("Images/Actors/Coroner"));
}