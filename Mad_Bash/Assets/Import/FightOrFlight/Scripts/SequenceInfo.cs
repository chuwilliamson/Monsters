
using UnityEngine;
 
[CreateAssetMenu(menuName = "Scriptables/SequenceInfo")]
public class SequenceInfo : ScriptableObject
{
    public StringVariable CurrentStateName;
    public StringVariable IntervalStringVariable; //no more score
    public StringVariable ScoreStringVariable;
    public StringVariable TimeToLiveStringVariable;
    public StringVariable TimeToPressStringVariable;
}
