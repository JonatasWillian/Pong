using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBase : MonoBehaviour
{
    [Header("Speed Ball")]
    public Vector3 speed = new Vector3(1, 1);

    [Header("Tag Player")]
    public string tagPlayer = "";

    [Header("Random")]
    public Vector2 randSpeedX = new Vector2(1, 3);
    public Vector2 randSpeedY = new Vector2(1, 3);

    private Vector3 _startPosition;
    private Vector3 startSpeed;
    private bool _canMove = false;

    private void Awake()
    {
        _startPosition = transform.position;
        startSpeed = speed;
    }

    void Update()
    {
        if (!_canMove) return;

        transform.Translate(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == tagPlayer)
        {
            OnPlayerCollision();
        }
        else
        {
            speed.y *= -1;
        }
    }

    private void OnPlayerCollision()
    {
        speed.x *= -1;

        float rand = Random.Range(randSpeedX.x, randSpeedX.y);

        if (speed.x < 0)
        {
            rand = -rand;
        }

        speed.x = rand;

        rand = Random.Range(randSpeedY.x, randSpeedY.y);
        speed.y = rand;
    }

    public void ResetBall()
    {
        transform.position = _startPosition;
        speed = startSpeed;
    }

    public void CanMove(bool state)
    {
        _canMove = state;
    }
}
