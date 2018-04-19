using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScaleSphereBehaviour : MonoBehaviour
{
    public FloatVariable Scale;

    public Vector3 StartScale;
	// Use this for initialization
	void Start ()
	{
	    StartScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update ()
	{
        transform.localScale = (StartScale * Scale.Value);
    }
}
