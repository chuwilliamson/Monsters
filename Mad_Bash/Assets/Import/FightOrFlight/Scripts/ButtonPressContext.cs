using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ButtonSequenceContext")]
public class ButtonPressContext : ScriptableObject, IContext
{
    [SerializeField] private List<int> ButtonPressStateIndices = new List<int>();
    [SerializeField] private List<ButtonPressObject> ButtonPressStates = new List<ButtonPressObject>();

    [Header("Events")]
    [SerializeField] private GameEventArgs _onContextChanged;
    [SerializeField] private GameEventArgs _onContextFinished;
    [SerializeField] private GameEventArgs _onContextReset;
    [SerializeField] private GameEventArgs _onContextTimerEnd;
    [SerializeField] private GameEventArgs _onContextTimerStart;
    
    [Header("Inspector Variables")]
    [SerializeField] [Range(0.1f, 5.0f)] private float _timeToLive;
    [SerializeField] [Range(0.1f, 5.0f)] private float _timeToPress;
    [SerializeField] [Range(0.1f, 5.0f)] private float _timeToTransition;
    [SerializeField] private bool _random;
    [SerializeField] private float _pressBufferMax = 1f;
    [SerializeField] private int _maxTurns;

    [Header("Display")]
    [ReadOnly]
    [SerializeField] private float _totalScore;
    [ReadOnly]
    [SerializeField] private int _turnCount;
    [ReadOnly]
    [SerializeField] private float _currentTransitionTime;
    [ReadOnly]
    [SerializeField] bool COMPLETE;
    public SequenceInfo SequenceInfo;

    public IState CurrentState
    { get; private set; }

    public float TimeToTransition
    {
        get { return _timeToTransition; }
        set { _timeToTransition = value; }
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
        _currentTransitionTime = _timeToTransition;
        _onContextTimerStart.Raise(this);
        TurnCount++;
        CurrentState = next;
        CurrentState.OnEnter(this);

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
        COMPLETE = false;
        ButtonPressStateIndices = new List<int>();

        for (var i = 0; i < _maxTurns; ++i)
            ButtonPressStateIndices.Add(UnityEngine.Random.Range(0, ButtonPressStates.Count));

        CurrentState = ButtonPressStates[ButtonPressStateIndices[TurnCount]];
        CurrentState.OnEnter(this);

        _currentTransitionTime = _timeToTransition;
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
            if (COMPLETE)
                return;

            COMPLETE = true;
            SequenceInfo.CurrentStateName.Value = "Finished with score of " + TotalScore;
            _onContextFinished.Raise(this);
            return;

        }

        //we do not update the current state when the transition is counting down
        //should look for a better way to do this since we can not have a 0 interval transition
        if (_currentTransitionTime > 0)
        {
            var newInterval = _currentTransitionTime - Time.deltaTime;
            if (newInterval < 0)
            {
                _currentTransitionTime = _timeToTransition;
                newInterval = 0;
                _onContextTimerEnd.Raise(this);
            }
            _currentTransitionTime = newInterval;
            SequenceInfo.CurrentStateName.Value = "Waiting...";
            SequenceInfo.IntervalStringVariable.Value = _currentTransitionTime.ToString();
            return;
        }

        CurrentState.UpdateState(this);
    }
}