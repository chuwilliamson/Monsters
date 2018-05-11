using System.Linq; 
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "GlobalGameManager")]
public class GlobalGameManager : ScriptableObject
{
    private static GlobalGameManager _instance; 
    public static GlobalGameManager Instance
    {
        get { return _instance ?? (_instance = Resources.FindObjectsOfTypeAll<GlobalGameManager>().FirstOrDefault()); }
    }

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

    public void VibrateController(int value)
    {
        XInputDotNetPure.GamePad.SetVibration(0, value, value);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(int scene)
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
    public void LoadSceneAdditive(int scene)
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(scene, UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }
}