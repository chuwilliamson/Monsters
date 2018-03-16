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
    private float characterSpeedLevel;    
    public float speedModifer;
    public GameObject _camera;
    public GameObject _model;

    private void Update()
    {
        // get input        
        float y = Input.GetAxis(yAxis.Value);
        float x = Input.GetAxis(xAxis.Value);

        // make input vector with respect to delta time     
        Vector3 input = new Vector3(y, 0, x) * Time.deltaTime;
        
        // check for 0 input
        if (input != Vector3.zero)
        {
            // get characters speed level
            characterSpeedLevel = GetComponent<PlayerObjectBehaviour>().CharacterInfo.Speed.Value;

            // get camera's forward vector
            Vector3 camForward = new Vector3(_camera.transform.forward.x, 0, _camera.transform.forward.z);

            // calculate translation direction with respect to camera's forward
            Vector3 translation = (input + camForward).normalized;

            Debug.Log("\n\n\n\n\n");
            Debug.Log("Input Vector: " + input.normalized.ToString());
            Debug.Log("Camera Forward: " + camForward.ToString());            
            Debug.Log("Translation Vector Direction: " + translation.ToString());
            
            // calculate coeffiect to use to modify translation vector
            float translationModifer = characterSpeedLevel * speedModifer;

            // apply translation vector to objects transform
            transform.Translate(translation * translationModifer);

            // model must face in direction of the player objects translation vector            
            _model.transform.forward = input.normalized;
            Debug.Log("Model Forward: " + _model.transform.forward.ToString());
            Debug.Log("\n\n\n\n\n");
        }
    }
}
