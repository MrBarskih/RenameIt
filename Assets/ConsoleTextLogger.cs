using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class ConsoleTextLogger : MonoBehaviour
{
    private TextMeshProUGUI gameConsole;
    private ConsoleTextConverter textConverter;


    private void Start()
    {
        textConverter= FindObjectOfType<ConsoleTextConverter>().GetComponent<ConsoleTextConverter>();
        gameConsole= GetComponent<TextMeshProUGUI>();
    }

    public void AddText(string text, WrapTags tags) 
    {
        text = textConverter.WrapTextInTags(text, tags);
        gameConsole.text += text;
    }

    public void NextLine()
    {
        gameConsole.text += "\n";
    }
}
