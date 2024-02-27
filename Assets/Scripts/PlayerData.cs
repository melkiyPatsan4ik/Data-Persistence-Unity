using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    public string playerName; // Player name field
    public string highscoreName;
    public int highscore; // Highscore field

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        LoadPlayerData();
    }

    [System.Serializable]
    public class SaveData
    {
        public string playerName;
        public string highscoreName;
        public int highscore;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.highscoreName = highscoreName;
        data.highscore = highscore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highscoreName = data.highscoreName;
            highscore = data.highscore;
        }
    }
}
