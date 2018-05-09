using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerBehaviour : MonoBehaviour
{
    public Camera mainCam;

    public float fadeTime = 1.0f;
    public float alpha = 0f; // color of the screen

    public GameObject plane;

    public void ChangeScene()
    {
        Instantiate<GameObject>(plane, mainCam.transform.position, mainCam.transform.rotation, mainCam.transform);

        this.StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(0);
    }
}