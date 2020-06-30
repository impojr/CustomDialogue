using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor
{
    public ActorList Id;
    public string FirstName;
    public string LastName;
    public EmotionSprites Emotions;

    public Actor(ActorList id, string firstName, string lastName, EmotionSprites emotions)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Emotions = emotions;
    }

    public string GetFullName()
    {
        return FirstName + " " + LastName;
    }
}