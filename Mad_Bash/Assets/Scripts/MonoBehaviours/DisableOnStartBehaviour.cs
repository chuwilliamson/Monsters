using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnStartBehaviour : MonoBehaviour
{
    public GameEventArgsResponse START_RESPONSE;
    public GameEventArgsResponse ONENABLE_RESPONSE;
    public GameEventArgsResponse ONDISABLE_RESPONSE;

    private void Start()
    {
        START_RESPONSE.Invoke(new Object[] { gameObject });
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        ONENABLE_RESPONSE.Invoke(new Object[] { gameObject });
    }

    private void OnDisable()
    {
        ONDISABLE_RESPONSE.Invoke(new Object[] { gameObject });
    }


}
