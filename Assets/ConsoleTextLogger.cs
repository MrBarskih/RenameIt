using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ConsoleTextLogger : MonoBehaviour
{
    public Color leftCornerColor;
    public Color rightCornerColor;

    private TextMeshProUGUI gameConsole;


    private void Start()
    {
        gameConsole = gameObject.GetComponent<TextMeshProUGUI>();

        AddLineOfText("hit from the left", ConsolePlace.Left);
        AddLineOfText("hit from the right", ConsolePlace.Right);
        AddLineOfText("hit from the commentator", ConsolePlace.Neutral);
    }

    public void AddLineOfText(string line, ConsolePlace place) 
    {
        string startTags = "";
        string endTags = "";
        switch (place) 
        {
            case ConsolePlace.Left:
                startTags = "<align=left><color=#" + ColorUtility.ToHtmlStringRGB(leftCornerColor) + ">";
                endTags = "</color></align>";
                break;
            case ConsolePlace.Right:
                startTags = "<align=right><color=#" + ColorUtility.ToHtmlStringRGB(rightCornerColor) + ">";
                endTags = "</color></align>";
                break;
            default:
                startTags = "<align=center>";
                endTags = "</align>";
                break;  
        }


        gameConsole.text += startTags + line + endTags + "\n";
    }
}
