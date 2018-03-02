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

        float sprint = character._speed * .0005f;

        transform.Translate(h, 0, v);

        if (Input.GetButton("Sprint") && v >= .01f)
            transform.Translate(h, 0, (v + sprint));

    }

    // Update is called once per frame
    void Update ()
    {
        Move();
    }
}
