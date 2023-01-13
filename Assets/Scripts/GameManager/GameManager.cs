using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("List Players")]
    public Player[] listPlayers;

    [Header("Ball Base")]
    public BallBase ballBase;
    public float timeSetBallFree = 1f;

    [Header("Menus")]
    public GameObject uiMainMenu;

    [Header("StateMachine")]
    public StateMachine stateMachine;

    [Header("Input")]
    public KeyCode keyCode = KeyCode.KeypadEnter;

    [Header("UI")]
    public GameObject uiPause;

    public static GameManager Instance;

    private bool _blocked;
    private bool _paused = false;

    private void Awake()
    {
        Instance = this;

        listPlayers = FindObjectsOfType<Player>();
    }

    private void Update()
    {
        MainPause();
    }

    public void MainPause()
    {
        if(Input.GetKeyDown(keyCode))
        {
            _paused = !_paused;
            Debug.Log("Pausing or unpausing game");
            Time.timeScale = _paused ? 0 : 1;
            uiPause.SetActive(true);
        }
    }

    public void PauseOn()
    {
        Time.timeScale = 0;
        uiPause.SetActive(true);
    }

    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), timeSetBallFree);
    }

    public void ResetPlayers()
    {
        foreach (var player in listPlayers)
        {
            player.ResetPlayer();
        }
    }

    private void SetBallFree()
    {
        if (_blocked) return;
        ballBase.CanMove(true);
    }

    public void StartGame()
    {
        ballBase.CanMove(true);
        _blocked = false;
    }

    public void EndGame()
    {
        stateMachine.SwitchState(StateMachine.States.END_GAME);
        _blocked = true;
    }

    public void ShowMainMenu()
    {
        uiMainMenu.SetActive(true);
        ballBase.CanMove(false);
    }
}
