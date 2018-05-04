using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[CreateAssetMenu(menuName ="GlobalGameManager")]
public class GlobalGameManager : ScriptableObject {

	public void PrintGameObject(GameObject go)
    {
        Debug.Log(go.name);
    }

    public void EventSystem_SetSelectedGameObject(GameObject go)
    {
        if (EventSystem.current == null)
        {
            Debug.LogError("EventSystem can not be found...");
            return;
        }
            
        EventSystem.current.SetSelectedGameObject(go);
        
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
