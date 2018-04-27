using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Button")]
public class ButtonCondition : ConditionVariable
{
    public bool _result;
    public string ButtonName;

    public override bool Result
    {
        get
        {
            _result = Input.GetButtonDown(ButtonName);
            return _result;
        }
    }
}