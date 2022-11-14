using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConsoleResizeOnWidowsChange : MonoBehaviour, IResizable
{
    private TextMeshProUGUI text;

    [SerializeField]
    [Range(0f, 2f)]
    private float fontSizePercents;

    private void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();

        text.fontSize = Screen.width / 100 * fontSizePercents;
    }

    public void ResizeIfWindowsWasChanged()
    {
        text.fontSize = Screen.width / 100 * fontSizePercents;
    }
}
