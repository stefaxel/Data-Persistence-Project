using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public string playerName;
    public TMP_InputField inputField;
    public TMP_Text highScoreText;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.interactable = false;
        DataManager.Instance.LoadSavedScore();
        highScoreText.text = $"Highscore: {DataManager.Instance.bestPlayer.ToUpper()}: {DataManager.Instance.highScore}";
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
Application.Quit();
#endif
     
    }

    public void StoreName()
    {
        startButton.interactable = true;
        playerName = inputField.text;
        DataManager.Instance.currentPlayer = playerName;
    }

}
