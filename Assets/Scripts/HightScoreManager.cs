using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HightScoreManager : MonoBehaviour
{
    [Header("Text")]
    public TextMeshProUGUI uiTextName;

    public static HightScoreManager Instance;

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
        if (p.playerName == "") return;
        PlayerPrefs.SetString(keyToSave, p.playerName);
        UpdateText();
    }
}
