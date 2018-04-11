using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PhysicsTriggerListener : MonoBehaviour
{
    [SerializeField]
    GameEventArgs onEnter;
    [SerializeField]
    GameEventArgs onExit;
    [SerializeField]
    GameEventArgs onStay;

    public StringVariable ListenerTag;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(ListenerTag.Value))
        {
            onEnter.Raise(gameObject, other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(ListenerTag.Value))
        {
            onExit.Raise(gameObject, other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(ListenerTag.Value))
        {
            onStay.Raise(gameObject, other.gameObject);
        }
    }
}
