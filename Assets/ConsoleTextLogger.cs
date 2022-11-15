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
    }

    public void AddLineOfText(string line, ConsolePlace place) 
    {
        string startTags = "";
        switch (place) 
        {
            case ConsolePlace.Left:
                    startTags = "<align=left><color=#" + ColorUtility.ToHtmlStringRGBA(leftCornerColor) + ">";
                break;
            case ConsolePlace.Right:
                    startTags = "<align=right><color=#" + ColorUtility.ToHtmlStringRGBA(rightCornerColor) + ">";
                break;
            default:
                    startTags = "<align=center>";
                break;  
        }


        gameConsole.text += startTags + line + "\n";
    }
}
