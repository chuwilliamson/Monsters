using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerBehaviour : MonoBehaviour
{
    public Camera mainCam;

    public float fadeTime = 1.0f;

    Color alpha; 

    public GameObject plane;

    public void ChangeScene()
    {
        Instantiate<GameObject>(plane, mainCam.transform.position + new Vector3(0f,.5f,-.75f), mainCam.transform.rotation * new Quaternion(0f,-100f,90f,0f), mainCam.transform);

        this.StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(0);
    }
}