using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveName : MonoBehaviour
{
    [Header("Player")]
    public Player player;

    [Header("Text")]
    public TextMeshProUGUI textPlayer;

    private string playerName;

    public void SaveTheName()
    {
        /*playerName = textPlayer.text;
        player.SetName(textPlayer);*/
    }
}
