using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SubmitHandlerImpl : MonoBehaviour ,UnityEngine.EventSystems.ISubmitHandler
{
    public GameEventArgsResponse Response;
    public void OnSubmit(BaseEventData eventData)
    {
        Response.Invoke(null);
    }
}
