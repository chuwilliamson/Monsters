using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public CharacterInfo player;

    float h;
    float v;
        
    void Move()
    {
        h = Input.GetAxis("Horizontal") * (player.Speed * .5f);
        v = Input.GetAxis("Vertical") * (player.Speed * .5f);

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
