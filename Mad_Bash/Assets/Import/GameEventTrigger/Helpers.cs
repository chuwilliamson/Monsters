
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

    public static void MoveInCamera(this GameObject gameObject, Vector3 newPos)
    {
        gameObject.transform.position = newPos;
        var pos = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.2f, 0.8f);
        pos.y = Mathf.Clamp(pos.y, 0.2f, 0.8f);
        pos.z = Mathf.Clamp(pos.z, 3, 6);
        gameObject.transform.position = Camera.main.ViewportToWorldPoint(pos);

        //var viewport = Camera.main.WorldToViewportPoint(gameObject.transform.position);
        //var worldpoint = Camera.main.ViewportToWorldPoint(viewport);        
        //gameObject.transform.position = worldpoint;
    }
}
