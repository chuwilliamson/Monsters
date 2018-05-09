#if UNITY_EDITOR
#endif
using UnityEngine;

/// <summary>
/// Does not go inside the Editor Folder
/// </summary>
public class ReadOnlyAttribute : PropertyAttribute { }

#if UNITY_EDITOR


#endif