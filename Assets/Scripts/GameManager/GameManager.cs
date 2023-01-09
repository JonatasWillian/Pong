using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Ball Base")]
    public BallBase ballBase;
    public float timeSetBallFree = 1f;

    public StateMachine stateMachine;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void ResetBall()
    {
        ballBase.CanMove(false);
        ballBase.ResetBall();
        Invoke(nameof(SetBallFree), timeSetBallFree);
    }

    private void SetBallFree()
    {
        ballBase.CanMove(true);
    }

    public void StartGame()
    {
        ballBase.CanMove(true);
    }
}
