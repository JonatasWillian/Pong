using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreManager : MonoBehaviour
{
    [Header("Text")]
    public TextMeshProUGUI uiTextName;

    public static HighScoreManager Instance;

    private string keyToSave = "KeyToSave";

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        uiTextName.text = PlayerPrefs.GetString(keyToSave, "Nothing");
    }

    public void SavePlayerWin(Player p)
    {
        PlayerPrefs.SetString(keyToSave, p.playerName.text);
        UpdateText();
    }
}
