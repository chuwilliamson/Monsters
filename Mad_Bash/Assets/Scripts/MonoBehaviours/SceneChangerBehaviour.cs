using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//Ryan

public class SceneChangerehaviour : MonoBehaviour
{
    public void ChangeScene(string name)
    {
        //if (Input.GetKey(KeyCode.Joystick1Button0))
            SceneManager.LoadScene(name);
    }

	
}
