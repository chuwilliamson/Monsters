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
            return _result;
        }
    }
}