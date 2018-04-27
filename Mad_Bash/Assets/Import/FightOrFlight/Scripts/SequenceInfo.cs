
using UnityEngine;
 
[CreateAssetMenu(menuName = "Scriptables/SequenceInfo")]
public class SequenceInfo : ScriptableObject
{
    public StringVariable InfoStringVariable;
    public StringVariable IntervalStringVariable; //no more score
    public StringVariable ScoreStringVariable;
    public StringVariable TimerStringVariable;
    public StringVariable TimerPressedStringVariable;
}
