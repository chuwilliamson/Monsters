using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_EquipBehaviour : MonoBehaviour
{
    bool equipped = false;

    public void Equip()
    {
        if (Input.GetButton("A Button"))
        {
            equipped = true;
        }

        if (equipped == true)
        {
            Instantiate(gameObject, gameObject.transform);
        }
    }
}
