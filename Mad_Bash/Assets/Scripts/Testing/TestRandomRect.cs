using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandomRect : MonoBehaviour
{
    public Canvas canvas;

    private void OnEnable()
    {
        //canvas = GetComponentInParent<Canvas>();
    }

    int counter;
    private void Update()
    {
        counter++;
        if (counter > 10)
        {
            var width = canvas.GetComponent<RectTransform>().rect.width;
            var height = canvas.GetComponent<RectTransform>().rect.height;

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
