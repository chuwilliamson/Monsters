using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModelBehaviour : MonoBehaviour
{	
	private void Update ()
    {
        float h = Input.GetAxis("LeftHorizontal");
        float v = Input.GetAxis("LeftVertical");

        Vector3 direction = new Vector3(h, 0, v) * Time.deltaTime;

        if(direction != Vector3.zero)
            transform.forward = direction;
    }
}
