using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [SerializeField]
    private float characterSpeed;    
    public float speedModifer;
    public GameObject _camera;
    public GameObject _model;

    private void Update()
    {
        // set speed modifer based on character speed stat
        characterSpeed = GetComponent<PlayerObjectBehaviour>().CharacterInfo.Speed.Value;

        // get input
        float h = Input.GetAxis("LeftHorizontal");
        float v = Input.GetAxis("LeftVertical");

        // make input vector out of input
        Vector3 input = new Vector3(h, 0, v) * Time.deltaTime;
        Vector3 camForward = new Vector3(_camera.transform.forward.x, 0, _camera.transform.forward.z); ;
        Vector3 translation = Vector3.zero;

        // check to see if any input vector was given
        if (input != Vector3.zero)
        {
            // add respect to camera's forward vector           
            transform.forward = camForward;

            // apply modifiers to translation vector
            translation = input * characterSpeed * speedModifer;            

            // apply translation vector to objects transform
            transform.Translate(translation);

            // model must face in direction of the player objects translation vector            
            _model.transform.forward = input.normalized;
        }
        Debug.Log("\n\n\n\n\n");
        Debug.Log("Input Vector: " + input.normalized.ToString());
        Debug.Log("Translation Vector: " + translation.normalized.ToString());
        Debug.Log("Model Forward: " + _model.transform.forward.ToString());        
        Debug.Log("Camera Forward: " + camForward.ToString());
        Debug.Log("\n\n\n\n\n");
    }
}
