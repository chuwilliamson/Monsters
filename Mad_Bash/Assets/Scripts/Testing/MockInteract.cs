using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockInteract : IInteractable {
    public MockInteract()
    {}

    public void Interact(object token)
    {
        Debug.Log(token.ToString());
    }
}