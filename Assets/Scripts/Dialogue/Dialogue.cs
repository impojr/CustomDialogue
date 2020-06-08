using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    public string sentence;
    public Sprite image;

    public static Dialogue Create (string name, string sentence, Sprite image = null)
    {
        return new Dialogue
        {
            name = name,
            sentence = sentence,
            image = image
        };
    }
}