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

    private void Awake()
    {
        Instance = this;

        listPlayers = FindObjectsOfType<Player>();
        PauseOn();
    }

    public void PauseOn()
    {
        if(Input.GetKeyDown(keyCode))
        {
            Debug.Log("Input");
            Time.timeScale = 0;
            uiPause.SetActive(true);
        }
    }

    /*public void PauseOff()
    {
        if (Input.GetKeyDown(keyCode))
        {
            Time.timeScale = 1;
            uiPause.SetActive(false);
        }
    }*/

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
