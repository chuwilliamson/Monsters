using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="GlobalGameManager")]
public class GlobalGameManager : ScriptableObject {

	public void PrintGameObject(GameObject go)
    {
        Debug.Log(go.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
