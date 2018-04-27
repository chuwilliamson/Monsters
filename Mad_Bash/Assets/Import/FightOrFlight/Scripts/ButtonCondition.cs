using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Button")]
public class ButtonCondition : ConditionVariable
{
    [SerializeField]
    private bool _result;
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