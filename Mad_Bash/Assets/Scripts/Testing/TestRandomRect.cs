using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandomRect : MonoBehaviour
{
    [SerializeField] private ButtonPressContext _buttonPressContext;
    [SerializeField] private ButtonPressObject _buttonState;
    public RectTransform rectTransform;

    public void MoveObject(float width, float height)
    {
        var newPos = RandomRectPos.RandomOnRect(width, height);
        gameObject.transform.localPosition = newPos;        
    }

    public void OnContextChange(Object[] args)
    {
        if (_buttonState != _buttonPressContext.CurrentState as ButtonPressObject)
            return;

        MoveObject(width: rectTransform.rect.width, height: rectTransform.rect.height);        
    }
}
