using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConsoleResizeOnWidowsChange : MonoBehaviour, IResizable
{
    private TextMeshPro text;

    private void Start()
    {
        text = this.GetComponent<TextMeshPro>();
    }

    public void ResizeIfWindowsWasChanged()
    {
        text.fontSize = 10;
    }
}
