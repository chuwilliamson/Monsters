using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;


public class AssetFinder : EditorWindow
{
    public static string targetFolder = "Assets/Resources/Prefabs";
    public static string targetType = "GameObject";

    List<string> guids = new List<string>();
    List<string> paths = new List<string>();
    List<GameObject> objs = new List<GameObject>();
    Vector2 pos;
    Editor GOEditor;
    [MenuItem("JeremyTools/AssetFinder")]
    static void Init()
    {
        var w = EditorWindow.CreateInstance<AssetFinder>();
        w.Show();
    }
    private void OnGUI()
    {        
        targetFolder = EditorGUILayout.TextField("target folder", targetFolder);
        targetType = EditorGUILayout.TextField("target type", targetType);

        if (GUILayout.Button("Find"))
            GetObjects();
        
        pos = EditorGUILayout.BeginScrollView(pos);
        foreach (var obj in objs)
        {           
            EditorGUILayout.ObjectField(obj, typeof(GameObject), false);
        }
        
        EditorGUILayout.EndScrollView();
        
        if(GOEditor != null)
            GOEditor.OnPreviewGUI(GUILayoutUtility.GetRect(500, 500), null);
    }

    private void OnSelectionChange()
    {
        GOEditor = Editor.CreateEditor(Selection.activeGameObject);
        
    }

    public void GetObjects()
    {
        objs = new List<GameObject>();

        foreach (var asset in AssetDatabase.FindAssets("t:" + targetType))
            guids.Add(asset);

        foreach (var guid in guids)
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);

            if (path.Contains(targetFolder))
                paths.Add(path);
        }

        foreach (var path in paths)
        {
            var obj = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            
            objs.Add(obj);
        }
    }
}

    //var objs = AssetDatabase.FindAssets("t:GameObject")
    //    .Select(guid => AssetDatabase.GUIDToAssetPath(guid))
    //    .Select(path => AssetDatabase.LoadAssetAtPath<GameObject>(path))
    //    .Where(go => go).ToList();
