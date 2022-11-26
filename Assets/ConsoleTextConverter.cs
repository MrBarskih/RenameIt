using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using ColorUtility = UnityEngine.ColorUtility;

public enum WrapTags
{
    Left,
    Right,
    Neutral,
    Underline
}

public class ConsoleTextConverter : MonoBehaviour
{
    [SerializeField]
    private Color leftColor;

    [SerializeField]
    private Color rightColor;

    [SerializeField]
    [Range(20, 200)]
    private int underlineTextScalerPercents;

    private class TextAlign
    {
        private TextAlign(string value) { Value = value; }

        public string Value { get; private set; }

        public static TextAlign Left { get { return new TextAlign("left"); } }
        public static TextAlign Right { get { return new TextAlign("right"); } }
        public static TextAlign Center { get { return new TextAlign("center"); } }
    }

    private void Start()
    {
        
    }

    public string WrapTextInTags(string text, WrapTags place)
    {
        switch (place)
        {
            case WrapTags.Left:
                text = wrapInAlignTags(text, TextAlign.Left.Value);
                text = wrapInColorTags(text, leftColor);
                break;
            case WrapTags.Right:
                text = wrapInAlignTags(text, TextAlign.Right.Value);
                text = wrapInColorTags(text, rightColor);
                break;
            case WrapTags.Underline:
                text = wrapInSizeTags(text, underlineTextScalerPercents.ToString());
                text = wrapInUndelineTags(text);
                break;
            default:
                text = wrapInAlignTags(text, TextAlign.Center.Value);
                break;
        }

        return text ;
    }

    private string wrapInColorTags(string text, Color color) 
    {
        return "<color=#" + ColorUtility.ToHtmlStringRGB(color) + ">" + text + "</color>";
    }

    private string wrapInAlignTags(string text, string align)
    {
        return "<align=" + align + ">" + text + "</align>";
    }

    private string wrapInSizeTags(string text, string size)
    {
        return "<size=" + size + "%>" + text + "</size>";
    }
    private string wrapInUndelineTags(string text)
    {
        return "<u>" + text + "</u>";
    }
}