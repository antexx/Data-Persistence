using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    public Text BestScoreText;

    private void Start()
    {
        if (DataManager.instance != null && DataManager.instance.highScoreName != "")
        {
            BestScoreText.text = "Best Score : "
                + DataManager.instance.highScoreName
                + " : "
                + DataManager.instance.highScore;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void NameEntered(string name)
    {
        DataManager.instance.playerName = name;
    }
}
