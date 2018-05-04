
using System.Collections.Generic;
using UnityEngine;


public static class ExtensionMethods
{
    public static string SplitOnCapitalLetters2(this string inputString)
    {
        var result = new System.Text.StringBuilder();

        foreach (var ch in inputString)
        {
            if (char.IsUpper(ch) && result.Length > 0)
                result.Append(' ');

            result.Append(ch);
        }

        return result.ToString();


    }
    public static void MoveObject(this GameObject gameObject, float width, float height)
    {        

        gameObject.transform.localPosition = RandomRectPos.RandomOnRect(width, height);
    }

    public static void MoveInCamera(this GameObject gameObject, Vector3 newPos, bool local = false)
    {
        var screenSpace = Camera.main.WorldToScreenPoint(newPos);
        if (local)
        {
            gameObject.transform.localPosition = Camera.main.ScreenToViewportPoint(screenSpace);
        }
        else
        {
            gameObject.transform.position = Camera.main.ScreenToViewportPoint(screenSpace);
        }
        
    }
}