using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation 
{
    public string name;
    public Sprite sprite;
    public TextBox[] textboxes = new TextBox[4];

    public void SetAsVisited(string text)
    {
        foreach (TextBox textBox in textboxes)
        {
            if (textBox != null && textBox.text == text)
            {
                textBox.visited = true;
            }
        }
    }
}

public class TextBox
{
    public string text;
    public bool visited;
}