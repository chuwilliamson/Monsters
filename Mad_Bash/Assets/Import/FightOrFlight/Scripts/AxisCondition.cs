using UnityEngine;

[CreateAssetMenu(menuName = "Conditions/Axis")]
public class AxisCondition : ConditionVariable
{
    public string AxisName;
    public bool Greater;
    public float Value;

    public override bool Result
    {
        get
        {
            Value = Input.GetAxis(AxisName);
            var result = Greater ? Input.GetAxis(AxisName) > 0 : Input.GetAxis(AxisName) < 0;
            return result;
        }
    }
}