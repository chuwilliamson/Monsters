
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


    /// <summary>
    /// Extension method for moving a GameObject within the cameras viewport given
    /// 
    /// Only use float values between 0.0 and 1.0 for the X and Y values.
    /// You may use any number for the Z value.
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="newPos"></param>
    public static void MoveInCamera(this GameObject gameObject, Vector3 newPos)
    {
        var pos = newPos;
        pos.x = Mathf.Clamp(pos.x, 0.2f, .8f);
        pos.y = Mathf.Clamp(pos.y, 0.2f, .8f);
        gameObject.transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
