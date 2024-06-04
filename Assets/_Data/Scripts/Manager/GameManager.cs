using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager: TienMonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    public TMP_Text UI_NumberOfHeartText;
    public TMP_Text Ui_ScoreText;
    public GameObject inGameMenu;

    //public bool isPaused = false;

    protected override void Awake()
    {
        if (GameManager.Instance != null) Debug.LogError("Only 1 GameManager allow");
        instance = this;

        base.Awake();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUINumOfHeartText();
        LoadUIScoreText();
        LoadInGameMenu();
    }

    protected virtual void LoadUINumOfHeartText()
    {
        if (this.UI_NumberOfHeartText != null) return;
        this.UI_NumberOfHeartText = GameObject.Find("NumOfHeartText").GetComponent<TMP_Text>();
        Debug.Log(transform.name + ": Load UI Number of heart text", gameObject);
    }

    protected virtual void LoadUIScoreText()
    {
        if (this.Ui_ScoreText != null) return;
        this.Ui_ScoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        Debug.Log(transform.name + ": Load UI Score text", gameObject);
    }

    protected virtual void LoadInGameMenu()
    {
        if (this.inGameMenu != null) return;
        this.inGameMenu = GameObject.Find("InGameMenu");
        inGameMenu.SetActive(false);
        Debug.Log(transform.name + ": Load InGame Menu", gameObject);
    }

    private void Update()
    {
        UI_NumberOfHeartText.text = "x" + PlayerCtrl.Instance.playerLife.Heart.ToString();
        Ui_ScoreText.text = ScoreManager.Instance.Score.ToString();
        ScoreManager.Instance.UpdateScore();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
