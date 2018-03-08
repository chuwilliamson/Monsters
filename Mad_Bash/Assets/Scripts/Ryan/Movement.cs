using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterInfo player;

    float h;
    float v;
        
    void Move()
    {
        h = Input.GetAxis("Horizontal") + player.Speed;
        v = Input.GetAxis("Vertical") + player.Speed;

        h *= Time.deltaTime;
        v *= Time.deltaTime;

        float sprint = player.Speed * .0005f;
        
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
