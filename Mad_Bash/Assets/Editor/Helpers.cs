using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Sometimes, it is useful to be able to run some editor script code in a project as soon as Unity launches without requiring action from the user.
/// You can do this by applying the InitializeOnLoad attribute to a class which has a static constructor. 
/// A static constructor is a function with the same name as the class, declared static and without a return type or parameters.
/// </summary>

[InitializeOnLoad]
public class ScriptableObjectHelpers
{
    static List<ScriptableObject> objectsToUnload;

    static ScriptableObjectHelpers()
    {
        objectsToUnload = new List<ScriptableObject>();
        EditorApplication.playModeStateChanged += EditorApplication_playModeStateChanged;
    }

    private static void EditorApplication_playModeStateChanged(PlayModeStateChange obj)
    {
        switch (obj)
        {
            case PlayModeStateChange.EnteredPlayMode:
                objectsToUnload = Resources.LoadAll<ScriptableObject>("").ToList();
                AssetDatabase.SaveAssets();
                break;

            case PlayModeStateChange.ExitingPlayMode:
                foreach (var so in objectsToUnload)
                    Resources.UnloadAsset(so);
                objectsToUnload.Clear();
                AssetDatabase.Refresh();
                break;
        }
    }
}