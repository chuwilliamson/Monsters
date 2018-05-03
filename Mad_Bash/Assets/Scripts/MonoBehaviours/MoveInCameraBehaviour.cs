using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInCameraBehaviour: MonoBehaviour
{
    public Camera cam;

    public Vector3 MoveInCamera()
    {
        float newX = Random.Range(0, cam.pixelWidth);
        float newY = Random.Range(0, cam.pixelHeight);
        
        return cam.ScreenToWorldPoint(new Vector3(newX, newY, 15));
    }

    int counter;
	void Update ()
    {
        counter++;
        if (counter > 10)
        {
            gameObject.transform.SetPositionAndRotation(MoveInCamera(), cam.transform.rotation);
            counter = 0;
        }
	}
}
