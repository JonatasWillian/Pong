using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    [Header("Player")]
    public Player player;

    [Header("Tag Ball")]
    public string tagBall = "";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == tagBall)
        {
            Debug.Log("Entrou no trigger");
            CountPoint();
        }
    }

    private void CountPoint()
    {
        StateMachine.Instance.ResetPosition();
        player.AddPoint();
    }
}
