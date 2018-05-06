using UnityEditor;
using UnityEngine;

/// <summary>
/// Readonly Property Drawer for the Readonly Attribute
/// Makes inspector fields non modifiable
/// </summary>
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property);
        GUI.enabled = true;
    }
}