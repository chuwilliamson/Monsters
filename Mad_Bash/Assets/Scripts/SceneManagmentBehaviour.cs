using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagmentBehaviour : MonoBehaviour
{
    public float fadeTime = 1.0f;
    public float alpha = 0f; // color of the screen

    Texture2D black;
    Rect Screen;

    public void ChangeScene()
    {
        this.StartCoroutine(WaitAndLoad());
        OnGUI();
    }
    
    void OnGUI()
    {
        Screen = new Rect(0, 0, Screen.width, Screen.height);

        GUI.DrawTexture(Screen, black);
    }
    
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(0);
    }
}
