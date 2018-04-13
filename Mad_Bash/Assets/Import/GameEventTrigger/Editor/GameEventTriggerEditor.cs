using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameEventTrigger))]
public class GameEventTriggerEditor : Editor
{ 
    private SerializedProperty _mEntriesProperty;
    private GUIContent _mIconToolbarMinus;
    private GUIContent _mEventIdName;
    private GUIContent[] _mEventTypes;
    private GUIContent _mAddButtonContent;
    private GUIContent _mSenderName;
    private string[] _names;
    private string[] names;
    private GameEventArgs[] _mGameEventArgs;
    protected virtual void OnEnable()
    {
        _mEntriesProperty = serializedObject.FindProperty("Entries");
        _mAddButtonContent = new GUIContent("Add New Event Type");
        _mSenderName = new GUIContent("Sender");
        _mEventIdName = new GUIContent("");
        _mIconToolbarMinus = new GUIContent(EditorGUIUtility.IconContent("Toolbar Minus"));
        _mIconToolbarMinus.tooltip = "Remove all events in this list.";
        var vars = AssetDatabase.FindAssets("t:GameEventArgs")
            .Select(AssetDatabase.GUIDToAssetPath)
            .Select(AssetDatabase.LoadAssetAtPath<GameEventArgs>)
            .Where(b => b).OrderBy(v => v.name).ToArray();

        names = vars.Select(t => t.name).ToArray();
        _names = new string[names.Length];
        int i = -1; 
        foreach (var n in names)
        {
            var allsplit = n.SplitOnCapitalLetters2();
            var index = allsplit.IndexOf(' ');            
            var first = allsplit.Substring(0, index);
            var second = n.Substring(index);
            _names[++i] = (first + "/" + second);
        }
            

        _mEventTypes = new GUIContent[_names.Length];
        _mGameEventArgs = new GameEventArgs[vars.Length];
        for (var index = 0; index < _names.Length; ++index)
        {
            _mEventTypes[index] = new GUIContent(_names[index]);
            _mGameEventArgs[index] = vars[index];
        }            
    }
    /// <summary>
    ///   <para>Implement specific EventTrigger inspector GUI code here. If you want to simply extend the existing editor call the base OnInspectorGUI () before doing any custom GUI code.</para>
    /// </summary>
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        var toBeRemovedEntry = -1;
        EditorGUILayout.Space();
        var vector2 = GUIStyle.none.CalcSize(_mIconToolbarMinus);
        for (var index = 0; index < _mEntriesProperty.arraySize; ++index)
        {
            var arrayElementAtIndex = _mEntriesProperty.GetArrayElementAtIndex(index);
            var propertyRelative1 = arrayElementAtIndex.FindPropertyRelative("Event");
            var propertyRelative2 = arrayElementAtIndex.FindPropertyRelative("Callback");
            var propertyRelative3 = arrayElementAtIndex.FindPropertyRelative("Name");
            var propertyRelative4 = arrayElementAtIndex.FindPropertyRelative("Sender");
            //set the name of the event box to the propertyname based on it's enumindex
            _mEventIdName.text = propertyRelative3.stringValue.Replace("/", "");
            
            GUI.enabled = false;
            EditorGUILayout.PropertyField(propertyRelative1, _mEventIdName, new GUILayoutOption[0]);
            GUI.enabled = true;
            EditorGUILayout.PropertyField(propertyRelative4, _mSenderName, new GUILayoutOption[0]);
            EditorGUILayout.PropertyField(propertyRelative2, _mEventIdName, new GUILayoutOption[0]);
            
            var lastRect = GUILayoutUtility.GetLastRect();

            if (GUI.Button(new Rect((float)((double)lastRect.xMax - (double)vector2.x - 8.0), lastRect.y + 1f, vector2.x, vector2.y), _mIconToolbarMinus, GUIStyle.none))
                toBeRemovedEntry = index;

            EditorGUILayout.Space();
        }

        if (toBeRemovedEntry > -1)
            RemoveEntry(toBeRemovedEntry);

        var rect = GUILayoutUtility.GetRect(_mAddButtonContent, GUI.skin.button);

        rect.x = rect.x + (float)((rect.width - 200.0) / 2.0);

        rect.width = 200f;
        if (GUI.Button(rect, _mAddButtonContent))
            ShowAddTriggermenu();

        serializedObject.ApplyModifiedProperties();
    }

    private void RemoveEntry(int toBeRemovedEntry)
    {
        _mEntriesProperty.DeleteArrayElementAtIndex(toBeRemovedEntry);
    }

    private void ShowAddTriggermenu()
    {
        var genericMenu = new GenericMenu();
        for (var index1 = 0; index1 < _mEventTypes.Length; ++index1)
        {
            var flag = true;
            for (var index2 = 0; index2 < _mEntriesProperty.arraySize; ++index2)
            {
                if (_mEntriesProperty.GetArrayElementAtIndex(index2).FindPropertyRelative("EnumIndex").intValue == index1)
                    flag = false;
            }

            if (flag)
                genericMenu.AddItem(_mEventTypes[index1], false, OnAddNewSelected, (object)index1);
            else
                genericMenu.AddDisabledItem(_mEventTypes[index1]);
        }
        genericMenu.ShowAsContext();
        Event.current.Use();
    }

    
    private void OnAddNewSelected(object index)
    {
        int num = (int)index;
        ++_mEntriesProperty.arraySize;
        _mEntriesProperty.GetArrayElementAtIndex(_mEntriesProperty.arraySize - 1).FindPropertyRelative("EnumIndex").intValue = num;
        _mEntriesProperty.GetArrayElementAtIndex(_mEntriesProperty.arraySize - 1).FindPropertyRelative("Name").stringValue = _names[num];
        _mEntriesProperty.GetArrayElementAtIndex(_mEntriesProperty.arraySize - 1).FindPropertyRelative("Event")
            .objectReferenceValue = _mGameEventArgs[num];
        serializedObject.ApplyModifiedProperties();
    }
}

