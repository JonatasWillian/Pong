using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Player Name")]
    public TextMeshProUGUI playerName;

    [Header("Speed")]
    public float speed = 10f;

    [Header("Keys")]
    public KeyCode keyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode keyCodeMoveDown = KeyCode.DownArrow;

    [Header("Rigdbody2D")]
    public Rigidbody2D myRigidbody2D;

    [Header("Points")]
    public int maxPoints = 2;
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    private void Awake()
    {
        ResetPlayer();
    }

    public void SetName(TextMeshProUGUI textMeshProUGUI)
    {
        playerName = textMeshProUGUI;
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKey(keyCodeMoveUp))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * speed);
        }
        else if (Input.GetKey(keyCodeMoveDown))
        {
            myRigidbody2D.MovePosition(transform.position + transform.up * -speed);
        }
    }

    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
        Debug.Log(currentPoints);
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if (currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            HighScoreManager.Instance.SavePlayerWin(this);
        }
    }
}
