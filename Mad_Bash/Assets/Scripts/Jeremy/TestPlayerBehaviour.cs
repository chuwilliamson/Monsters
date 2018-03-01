using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerBehaviour : MonoBehaviour
{
    public int health;

    public void TakeDamage()
    {
        health -= 10;
        Debug.Log("took damage");
    }
}
