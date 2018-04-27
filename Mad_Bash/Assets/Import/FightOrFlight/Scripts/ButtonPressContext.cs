using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ButtonSequenceContext")]
public class ButtonPressContext : ScriptableObject, IContext
{ 
    public SequenceInfo SequenceInfo;

    [Header("Events")]
    [SerializeField] private GameEventArgs _onContextChanged;
    [SerializeField] private GameEventArgs _onContextFinished;
    [SerializeField] private GameEventArgs _onContextReset;
    [SerializeField] private GameEventArgs _onContextTimerEnd;
    [SerializeField] private GameEventArgs _onContextTimerStart;

    [Header("Inspector Variables")]
    [SerializeField] private float _timeToLive;
    [SerializeField] private float _timeToPress;
    [SerializeField] private int _maxTurns;
    [SerializeField] private float _transitionDuration;
    [SerializeField] private bool _random;

    [Header(("Display"))]
    [SerializeField] private float _totalScore;
    [SerializeField] private float _currentTransitionTime;
    [SerializeField] private int _turnCount;

    [SerializeField]
    public List<ButtonPressObject> ButtonPressStates = new List<ButtonPressObject>();

    private void OnEnable()
    {
        if (ButtonPressStates.Count <= 0)
            return;
       
        ResetContext();
    }
 
    public IState CurrentState
    { get; private set; }

    public float TransitionDuration
    {
        get { return _transitionDuration; }
        set { _transitionDuration = value; }
    }
    public int TurnCount
    {
        get { return _turnCount; }
        set
        {
            _turnCount = value;
            _onContextChanged.Raise(this);
            if (_turnCount == _maxTurns)
                _onContextFinished.Raise(this);
        }
    }

    public float TotalScore
    {
        get { return _totalScore; }
        set
        {
            _totalScore = value; 
            SequenceInfo.ScoreStringVariable.Value = _totalScore.ToString();
        }
    }

    public bool Random
    {
        get { return _random; }
        set { _random = value; }
    }
    public void ResetContext()
    {
      

        CurrentState = ButtonPressStates[0];
        TurnCount = 0;
        TotalScore = 0;
        _currentTransitionTime = _transitionDuration;
        CurrentState.OnEnter(this);
        SequenceInfo.IntervalStringVariable.Value = _currentTransitionTime.ToString();
        _onContextReset.Raise(this);
    }

    public void UpdateContext()
    {
        ButtonPressStates.ForEach(x => x.TTL = _timeToLive);
        ButtonPressStates.ForEach(x => x.Random = _random);
        ButtonPressStates.ForEach(x => x.TTP = _timeToPress);

        if (TurnCount >= _maxTurns)
        {
            SequenceInfo.InfoStringVariable.Value = "Finished with score of " + TotalScore;
            return;
        }
        if (_currentTransitionTime <= 0) // this happens only on frames the timer is not counting down.
        {
            CurrentState.UpdateState(this);
        }
        else // this happens only on frames the timer is counting down
        {
            var newInterval = _currentTransitionTime - Time.deltaTime;
            if (newInterval < 0)
            {
                _currentTransitionTime = _transitionDuration;
                newInterval = 0;
                _onContextTimerEnd.Raise(this);
            }
            _currentTransitionTime = newInterval;
            SequenceInfo.InfoStringVariable.Value = "Waiting...";
            SequenceInfo.IntervalStringVariable.Value = _currentTransitionTime.ToString();
        }
    }

    public void ChangeState(IState next)
    {
        CurrentState.OnExit(this);

        TurnCount++;
        CurrentState = next;
        CurrentState.OnEnter(this); 
        _currentTransitionTime = _transitionDuration;
        _onContextTimerStart.Raise(this);
    }

    
}