using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandomRect : MonoBehaviour
{
    public RectTransform rectTransform;

    int counter;
    private void Update()
    {
        counter++;
        if (counter > 20)
        {
            var width = rectTransform.rect.width;
            var height = rectTransform.rect.height;

            MoveObject(width, height);
            counter = 0;
        }        
    }

    public void MoveObject(float width, float height)
    {
        var newPos = RandomRectPos.RandomOnRect(width, height);
        gameObject.transform.localPosition = newPos;
    }      
}
