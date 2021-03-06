﻿using ChuTools;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Ring))]
public class RingPropertyDrawer : PropertyDrawer
{
    float _minVal = 1;
    float _minLimit = 0;
    float _maxVal = 2;
    float _maxLimit = 5;

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return 100f;
    }

 
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        EditorGUI.BeginProperty(position, new GUIContent(property.displayName), property);
       
        var rects = new Rect[5];
        for (int i = 0; i < 5; ++i)
            rects[i] = new Rect(position.x, position.y + i * 20, position.width, position.height);

        var minrect = position;
        minrect.width -= 20;
        EditorGUI.MinMaxSlider(minrect, new GUIContent(property.displayName), ref _minVal, ref _maxVal, _minLimit, _maxLimit);

        property.FindPropertyRelative("minVal").floatValue = _minVal;
        property.FindPropertyRelative("minLimit").floatValue = _minLimit;
        property.FindPropertyRelative("maxVal").floatValue = _minVal;
        property.FindPropertyRelative("maxLimit").floatValue = _maxLimit;

        EditorGUI.LabelField(rects[1], "MinVal", _minVal.ToString());
        EditorGUI.LabelField(rects[2], "MaxVal", _maxVal.ToString());
        EditorGUI.LabelField(rects[3], "MinLimit", _minLimit.ToString());
        EditorGUI.LabelField(rects[4], "MaxLimit", _maxLimit.ToString());


        EditorGUI.EndProperty();

    }
}