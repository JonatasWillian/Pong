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
    public float delayInitial = 2.5f;

    [Header("Menus")]
    public GameObject uiMainMenu;

    [Header("StateMachine")]
    public StateMachine stateMachine;

    [Header("Input")]
    public KeyCode keyCode = KeyCode.KeypadEnter;

    [Header("UI")]
    public GameObject uiPause;
    public GameObject division;

    public static GameManager Instance;

    private bool _blocked;
    private bool _paused = false;

    private Coroutine delayUnPauseCoroutine = null;

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
            if (_paused)
            {
                Time.timeScale = 0;
                uiPause.SetActive(true);
                division.SetActive(false);

                if (delayUnPauseCoroutine != null)
                    StopCoroutine(delayUnPauseCoroutine);
            }
            else
            {
                uiPause.SetActive(false);
                division.SetActive(true);
                PauseOff();
            }
        }
    }

    public void PauseOff()
    {
        if(delayUnPauseCoroutine != null)
            StartCoroutine(DelayTimeScale());
        delayUnPauseCoroutine = StartCoroutine(DelayTimeScale());
    }

    IEnumerator DelayTimeScale()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Time.timeScale = 1;
        delayUnPauseCoroutine = null;
        yield break;
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
        StartCoroutine(DelayBall());
        _blocked = false;
    }

    IEnumerator DelayBall()
    {
        yield return new WaitForSeconds(delayInitial);
        ballBase.CanMove(true);
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
