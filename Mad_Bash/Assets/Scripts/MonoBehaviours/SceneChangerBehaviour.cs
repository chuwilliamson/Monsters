using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//Ryan

public class SceneChangerBehaviour : MonoBehaviour
{
    public void ChangeScene(string name)
    {
            SceneManager.LoadScene(name);
    }

    //void B_Button()
    //{
    //    if (Input.GetButtonDown("B Button"))
    //        SceneManager.LoadScene("2.SafeHouse");
    //}

    //void Update()
    //{
    //    B_Button();    
    //}
}
