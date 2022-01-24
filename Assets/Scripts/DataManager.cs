using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string playerName;
    public string highScoreName;
    public int highScore;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    [System.Serializable]
    class HighScore
    {
        public string highScoreName;
        public int highScore;
    }

    public void SaveHighScore()
    {
        HighScore data = new HighScore();
        data.highScoreName = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";

        if (!File.Exists(path))
        {
            return;
        }

        string json = File.ReadAllText(path);
        HighScore data = JsonUtility.FromJson<HighScore>(json);
        highScore = data.highScore;
        highScoreName = data.highScoreName;
    }
}
