using System.Linq;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

/// <summary>
/// The following Editor Window will display all GameEventArgs Objects
/// and allow the use to manually invoke those events
/// It also shows all active listeners 
/// </summary>
public class GameEventEditorWindow : EditorWindow
{
    private List<GameEventArgs> GameEvents = new List<GameEventArgs>();

    [MenuItem("Tools/GameEventEditorWindow")]
    private static void Init()
    {
        var w = GetWindow(typeof(GameEventEditorWindow));
        w.Show();

    }

    private void OnEnable()
    {
        var assets = AssetDatabase.FindAssets("t:GameEventArgs")
            .Select(AssetDatabase.GUIDToAssetPath)
            .Select(AssetDatabase.LoadAssetAtPath<GameEventArgs>)
            .Where(gameevent => gameevent).ToList();
        GameEvents = new List<GameEventArgs>(assets);
    }


    private void OnInspectorUpdate()
    {
        Repaint();
    }

    private void OnGUI()
    {
        EditorGUILayout.Space();

        EditorGUILayout.TextField("GameEventArgs");
        DrawObjectsView();

        if (GUI.changed)
            Repaint();
    }

    private void DrawObjectsView()
    {
        EditorGUILayout.BeginVertical();

        foreach (var Event in GameEvents)
        {
            EditorGUILayout.BeginHorizontal();
            var listeners = Event.listeners.Select(x => ((MonoBehaviour)x).gameObject).ToList();
            EditorGUILayout.ObjectField(Event, typeof(GameEventArgs), false, GUILayout.Width(250));
            if (GUILayout.Button("Raise", GUILayout.Width(250)))
            {
                Event.Raise(null);
            }
            EditorGUILayout.EndHorizontal();


            EditorGUILayout.BeginVertical();
            EditorGUI.indentLevel++;
            listeners.ForEach(listener => EditorGUILayout.ObjectField(listener, typeof(GameObject), false, GUILayout.Width(250)));
            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.EndVertical();
    }
}
