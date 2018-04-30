using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStartBehaviour : MonoBehaviour 
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
}
