using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Facehead

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private StringVariable xAxis;
    [SerializeField]
    private StringVariable yAxis;

    [SerializeField]
    public GameObject _camera;
    [SerializeField]
    public GameObject _model;

    [SerializeField]
    private float characterSpeedLevel;
    [SerializeField]
    public float speedModifer;    

    private void Update()
    {
        // get characters speed level
        characterSpeedLevel = GetComponent<PlayerObjectBehaviour>().CharacterInfo.Speed.Value;

        MovePlayer();
    }

    public void MovePlayer()
    {
        // get input vector with respect to delta time
        float x = Input.GetAxis(xAxis.Value); // horizontal
        float y = Input.GetAxis(yAxis.Value); // vertical
        Vector3 input = new Vector3(x, 0, y) * Time.deltaTime;

        // check for 0 input
        if (input == Vector3.zero)
            return;

        Debug.Log("Input given");
        Debug.Log(input.ToString());

        // get camera's forward vector
        Vector3 camForward = new Vector3(_camera.transform.forward.x, 0, _camera.transform.forward.z);

        // calculate translation direction with respect to camera's forward
        Vector3 translation = input - camForward;
        Debug.Log(translation.ToString());

        // apply translation vector to objects transform
        transform.Translate(translation);
    }
}
