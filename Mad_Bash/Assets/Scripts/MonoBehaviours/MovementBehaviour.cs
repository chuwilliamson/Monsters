using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ryan

public class MovementBehaviour : MonoBehaviour
{
    public CharacterInfo player;

    float h;
    float v;
        
    void Move()
    {
        h = Input.GetAxis("LeftHorizontal") * (player.Speed * .5f);
        v = Input.GetAxis("LeftVertical") * (player.Speed * .5f);

        h *= Time.deltaTime;
        v *= Time.deltaTime;

        float sprint = player.Speed * .005f;
        
        transform.Translate(h, 0, v);

        if (Input.GetButton("RightBumper") && v >= .01f)
            transform.Translate(-h, 0, (v + sprint));

    }

    // Update is called once per frame
    void Update ()
    {
        Move();
    }
}
