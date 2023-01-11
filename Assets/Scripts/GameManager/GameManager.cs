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
    public KeyCode keyCodeESC = KeyCode.Escape;

    [Header("UI")]
    public GameObject uiPause;

    public static GameManager Instance;

    private bool _blocked;
    private bool _podePausar = false;

    private void Awake()
    {
        Instance = this;

        listPlayers = FindObjectsOfType<Player>();
        PauseOn();
    }

    public void PauseOn()
    {
        //if (_podePausar) return;

        if(Input.GetKeyDown(keyCodeESC))
        {
            Debug.Log("ESC");
            Time.timeScale = 0;
            uiPause.SetActive(true);
        }
    }

    /*public void PauseOff()
    {
        if (Input.GetKeyDown(keyCodeESC))
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
        _podePausar = true;
    }

    public void EndGame()
    {
        stateMachine.SwitchState(StateMachine.States.END_GAME);
        _blocked = true;
        _podePausar = false;
    }

    public void ShowMainMenu()
    {
        uiMainMenu.SetActive(true);
        ballBase.CanMove(false);
    }
}
