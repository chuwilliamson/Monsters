using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputDpads : MonoBehaviour
{
    public StringVariable DpadHorizontal;

    public StringVariable DpadVertical;

    public Vector2 DpadInput;
	
	// Update is called once per frame
	void Update ()
	{
	    DpadInput = new Vector2(Input.GetAxis(DpadHorizontal.Value), Input.GetAxis(DpadVertical.Value));
	}
}
