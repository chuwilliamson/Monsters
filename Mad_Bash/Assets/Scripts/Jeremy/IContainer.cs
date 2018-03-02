using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IContainer
{
    void AddContent(Object obj);
    void RemoveContent(Object obj);
}
