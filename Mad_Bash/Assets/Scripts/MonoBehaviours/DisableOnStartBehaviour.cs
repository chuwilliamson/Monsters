using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class DisableOnStartBehaviour : MonoBehaviour
{
    public GameEventArgsResponse START_RESPONSE;
    public GameEventArgsResponse ONENABLE_RESPONSE;
    public GameEventArgsResponse ONDISABLE_RESPONSE;


    private void Start()
    {
        if (START_RESPONSE.GetPersistentEventCount() <= 0)
            START_RESPONSE.AddListener(delegate { gameObject.SetActive(false); });
        START_RESPONSE.Invoke(new Object[] { gameObject }); 
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
