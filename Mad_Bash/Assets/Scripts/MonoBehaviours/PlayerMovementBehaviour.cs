using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        speed = GetComponent<CharacterInformation>().Speed.Value;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float h = 0;
        float v = 0;

        h = Input.GetAxis("LeftHorizontal") * (speed * .5f);
        v = Input.GetAxis("LeftVertical") * (speed * .5f);

        h *= Time.deltaTime;
        v *= Time.deltaTime;

        float sprint = speed * .005f;

        transform.Translate(h, 0, v);

        if (Input.GetButton("RightBumper") && v >= .01f)
            transform.Translate(h, 0, (v + sprint));
    }
}
