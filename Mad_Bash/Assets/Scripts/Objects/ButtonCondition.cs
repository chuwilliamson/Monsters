using UnityEngine;

[CreateAssetMenu(menuName ="Conditions/Button")]
public class ButtonCondition : ConditionVariable
{
    public string ButtonName;
    public bool _result;
    public override bool Result
    {
        get
        {
            _result = Input.GetButtonDown(ButtonName);
            if (_result)
                Debug.Log("WINNER");
            return _result;
        }
    }
}