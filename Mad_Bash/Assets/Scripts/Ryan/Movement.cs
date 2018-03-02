using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterInfo character;

    float h;
    float v;
        
    void Move()
    {
        h = Input.GetAxis("Horizontal") * character._speed;
        v = Input.GetAxis("Vertical") * character._speed;

        h *= Time.deltaTime;
        v *= Time.deltaTime;

        Vector3 sprint = transform.forward;

        transform.Translate(h, 0, v);
    }

    // Update is called once per frame
    void Update ()
    {
        Move();
    }
}
