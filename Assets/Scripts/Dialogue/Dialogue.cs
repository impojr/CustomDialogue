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
        return new Dialogue
        {
            name = actor.name,
            sentence = sentence,
            image = EmotionHelper.GetSpriteOfEmotion(emotion, actor)
        };
    }
}