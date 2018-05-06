
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class GameObjectBehaviour : MonoBehaviour
{
    public UnityEvent _Start;
    public UnityEvent _OnEnable;
    public UnityEvent _OnDisable;
    private void OnEnable() { _OnEnable.Invoke(); }
    private void Start() { _Start.Invoke(); }
    private void OnDisable() { _OnDisable.Invoke(); }



}
