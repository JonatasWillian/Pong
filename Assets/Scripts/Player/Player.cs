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

    [Header("Rect")]
    public RectTransform _topBorder;
    public RectTransform _botBorder;
    public RectTransform cube;

    private float _maxY;
    private float _minY;

    private RectTransform _playerRectTranform;

    private void Awake()
    {
        ResetPlayer();

        if (cube != null)
        {
            print("cube anchored position " + cube.anchoredPosition + " offsetmax: " + cube.offsetMax);
        }
        else
        {
            return;
        }

        _playerRectTranform = GetComponent<RectTransform>();
        Rect playerRect = Utility.GetScreenPositionFromRect(_playerRectTranform, Camera.main);

        Rect topBorderRect = Utility.GetScreenPositionFromRect(_topBorder, Camera.main);
        Rect bopBorderRect = Utility.GetScreenPositionFromRect(_botBorder, Camera.main);

        _maxY = (Screen.height - topBorderRect.yMin) - playerRect.size.y / 2;
        _minY = (Screen.height - bopBorderRect.yMax) + playerRect.size.y / 2;

        _maxY = Camera.main.ScreenToWorldPoint(new Vector2(0, _maxY)).y;
        _minY = Camera.main.ScreenToWorldPoint(new Vector2(0, _minY)).y;
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
            Vector2 finalPos = transform.position + transform.up * speed * Time.deltaTime;
            if (finalPos.y < _maxY)
            {
                myRigidbody2D.MovePosition(finalPos);
            }
        }
        else if (Input.GetKey(keyCodeMoveDown))
        {
            Vector2 finalPos = transform.position + transform.up * -speed * Time.deltaTime;
            if (finalPos.y > _minY)
            {
                myRigidbody2D.MovePosition(finalPos);
            }
        }
    }

    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
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
