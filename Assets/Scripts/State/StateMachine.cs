using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        MENU,
        PLAYING,
        RESET_POSITION,
        END_GAME
    }

    public Dictionary<States, StateBase> dictionaryStates;

    public float timeStartGame = 1f;

    private StateBase _currentState;

    public static StateMachine Instance;

    private void Awake()
    {
        Instance = this;

        dictionaryStates = new Dictionary<States, StateBase>();
        dictionaryStates.Add(States.MENU, new StateBase());
        dictionaryStates.Add(States.PLAYING, new StatePlaying());
        dictionaryStates.Add(States.RESET_POSITION, new StateResetPosition());
        dictionaryStates.Add(States.END_GAME, new StateEndGame());

        SwitchState(States.MENU);
    }

    public void SwitchState(States states)
    {
        if (_currentState != null) _currentState.OnStateExit();

        _currentState = dictionaryStates[states];

        if(_currentState != null) _currentState.OnStateEnter();
    }

    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
    }

    public void ResetPosition()
    {
        SwitchState(States.RESET_POSITION);
    }
}
