using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public TMP_InputField input;
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void saveName()
    {
        PlayerData.Instance.playerName = input.text;
        PlayerData.Instance.SavePlayerData();
    }
}
