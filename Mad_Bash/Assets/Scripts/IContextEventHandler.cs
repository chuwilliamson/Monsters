using UnityEngine;
public interface IContextEventHandler
{
    void onContextTimerStart(Object[] args);
    void onContextTimerEnd(Object[] args);
    void onContextChanged(Object[] args);
    void onContextFinished(Object[] args);
 

}
