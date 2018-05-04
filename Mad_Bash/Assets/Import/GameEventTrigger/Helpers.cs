
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

    public static void MoveInCamera(this GameObject gameObject, float distance=5.0f)
    {
        float newX = Random.Range(0, Camera.main.pixelWidth);
        float newY = Random.Range(0, Camera.main.pixelHeight);

        gameObject.transform.position  = 
            Camera.main.ScreenToWorldPoint(new Vector3(newX, newY, distance));
    }
}