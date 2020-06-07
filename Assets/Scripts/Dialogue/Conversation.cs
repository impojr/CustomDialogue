using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation 
{
    public string name;
    public Sprite sprite;
    public TextBox textbox1;
    public TextBox textbox2;
    public TextBox textbox3;
    public TextBox textbox4;

    public void SetAsVisited(string text)
    {
        if (textbox1.text == text)
        {
            textbox1.visited = true;
        }

        if (textbox2 != null && textbox2.text == text)
        {
            textbox2.visited = true;
        }

        if (textbox3 != null && textbox3.text == text)
        {
            textbox3.visited = true;
        }

        if (textbox4 != null && textbox4.text == text)
        {
            textbox4.visited = true;
        }
    }
}

public class TextBox
{
    public string text;
    public bool visited;
}