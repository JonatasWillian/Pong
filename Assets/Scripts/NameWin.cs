using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameWin : MonoBehaviour
{
    [Header("Player")]
    public Player player;
    public TextMeshProUGUI textPlayer;
    public TextMeshProUGUI hightScore;

    public void SaveName()
    {
        textPlayer.text = hightScore.text;
        player.SetName(textPlayer);
    }
}
