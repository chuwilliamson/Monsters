using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ButtonSequenceContext")]
public class ButtonPressContext : ScriptableObject, IContext
{
    [SerializeField] private float _currentTransitionTime;

    [SerializeField] private int _maxTurns;

    [Header("Events")] [SerializeField] private GameEventArgs _onContextChanged;

    [SerializeField] private GameEventArgs _onContextFinished;

    [SerializeField] private GameEventArgs _onContextReset;

    [SerializeField] private GameEventArgs _onContextTimerEnd;

    [SerializeField] private GameEventArgs _onContextTimerStart;
    [SerializeField] private float _pressBufferMax = 1f;

    [SerializeField] private bool _random;

    [Header("Inspector Variables")] [SerializeField] private float _timeToLive;

    [SerializeField] private float _timeToPress;

    [Header("Display")] [SerializeField] private float _totalScore;

    [SerializeField] private float _transitionDuration;

    [SerializeField] private int _turnCount;
    [SerializeField] public List<int> ButtonPressStateIndices = new List<int>();
    [SerializeField] public List<ButtonPressObject> ButtonPressStates = new List<ButtonPressObject>();

    public SequenceInfo SequenceInfo;

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

    public ButtonPressObject NextState
    {
        get
        {
            var nextindex = _turnCount + 1 >= _maxTurns ? 0 : _turnCount + 1;
            return ButtonPressStates[ButtonPressStateIndices[nextindex]];
        }
    }

    public void ChangeState(IState next)
    {
        ButtonPressStates.ForEach(x => x.TTL = _timeToLive);
        ButtonPressStates.ForEach(x => x.TTP = _timeToPress);
        ButtonPressStates.ForEach(x => x.Random = _random);
        ButtonPressStates.ForEach(x => x.PressBufferMax = _pressBufferMax);

        CurrentState.OnExit(this);
        TurnCount++;
        CurrentState = next;
        CurrentState.OnEnter(this);
        _currentTransitionTime = _transitionDuration;
        _onContextTimerStart.Raise(this);
    }

    private void OnEnable()
    {
        if (ButtonPressStates.Count <= 0)
            return;

        ResetContext();
    }

    public void ResetContext()
    {
        TurnCount = 0;
        TotalScore = 0;
        ButtonPressStateIndices = new List<int>();

        for (var i = 0; i < _maxTurns; ++i)
            ButtonPressStateIndices.Add(UnityEngine.Random.Range(0, ButtonPressStates.Count));

        CurrentState = ButtonPressStates[ButtonPressStateIndices[TurnCount]];

        _currentTransitionTime = _transitionDuration;
        CurrentState.OnEnter(this);
        SequenceInfo.IntervalStringVariable.Value = _currentTransitionTime.ToString();
        _onContextReset.Raise(this);
    }

    public void UpdateContext()
    {
        SequenceInfo.TimeToLiveStringVariable.Value = ((ButtonPressObject)CurrentState).CurrentTimeToLive.ToString();
        SequenceInfo.TimeToPressStringVariable.Value = ((ButtonPressObject)CurrentState).CurrentTimeToPress.ToString();
        SequenceInfo.CurrentStateName.Value = ((ButtonPressObject)CurrentState).name; 

        if (TurnCount >= _maxTurns)
        {
            SequenceInfo.CurrentStateName.Value = "Finished with score of " + TotalScore;
            return;
        }

        if (_currentTransitionTime <= 0)
        {
            CurrentState.UpdateState(this);
        }
        else
        {
            var newInterval = _currentTransitionTime - Time.deltaTime;
            if (newInterval < 0)
            {
                _currentTransitionTime = _transitionDuration;
                newInterval = 0;
                _onContextTimerEnd.Raise(this);
            }
            _currentTransitionTime = newInterval;
            SequenceInfo.CurrentStateName.Value = "Waiting...";
            SequenceInfo.IntervalStringVariable.Value = _currentTransitionTime.ToString();
        }
    }
}