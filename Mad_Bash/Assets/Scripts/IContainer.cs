using UnityEngine;

public interface IContainer
{
    bool AddContent(Object obj);
    bool RemoveContent(Object obj);
}