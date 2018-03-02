using UnityEngine;

public class TestBehaviour : MonoBehaviour
{
    public void Test(UnityEngine.Object[] args)
    {
        var sender = args[0] as GameObject;
        var player = args[1] as GameObject;

        Debug.Log("sender is " + args[0]);
        Debug.Log("collided with " + args[1]);
    }
}
