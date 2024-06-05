using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager: TienMonoBehaviour
{
    static private GameManager instance;
    static public GameManager Instance { get => instance; }

    public TMP_Text UI_NumberOfHeartText;
    public TMP_Text UI_ScoreText;

    [Header("In Game Menu")]
    [Header("Text")]
    public TMP_Text UI_YourScoreText;
    public TMP_Text UI_NewHighScoreText;

    [Header("Button")]
    public Button UI_PauseButton;
    public Button UI_ResumeButton;
    public Button UI_RestartButton;
    public Button UI_BackToMenuButton;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIText();
        LoadUIButton();
    }

    protected virtual void LoadUIText()
    {
        if (this.UI_NumberOfHeartText == null)
        {
            this.UI_NumberOfHeartText = GameObject.Find("NumOfHeartText").GetComponent<TMP_Text>();
            Debug.Log(transform.name + ": Load UI Number of heart text", gameObject);
        }
        
        if (this.UI_ScoreText == null)
        {
            this.UI_ScoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
            Debug.Log(transform.name + ": Load UI Score text", gameObject);
        }
        
        if (this.UI_YourScoreText == null)
        {
            this.UI_YourScoreText = GameObject.Find("YourScoreText").GetComponent<TMP_Text>();
            this.UI_YourScoreText.gameObject.SetActive(false);
            Debug.Log(transform.name + ": Load UI Your score text", gameObject);
        }
        
        if (this.UI_NewHighScoreText == null)
        {
            this.UI_NewHighScoreText = GameObject.Find("NewHighScoreText").GetComponent<TMP_Text>();
            this.UI_NewHighScoreText.gameObject.SetActive(false);
            Debug.Log(transform.name + ": Load UI New Highscore text", gameObject);
        } 
    }

    protected virtual void LoadUIButton()
    {
        if (this.UI_PauseButton == null)
        {
            this.UI_PauseButton = GameObject.Find("PauseButton").GetComponent<Button>();
            Debug.Log(transform.name + ": Load Pause button", gameObject);
        }

        if (this.UI_ResumeButton == null)
        {
            this.UI_ResumeButton = GameObject.Find("ResumeButton").GetComponent<Button>();
            this.UI_ResumeButton.gameObject.SetActive(false);
            Debug.Log(transform.name + ": Load Resume button", gameObject);
        }

        if (this.UI_RestartButton == null)
        {
            this.UI_RestartButton = GameObject.Find("RestartButton").GetComponent<Button>();
            this.UI_RestartButton.gameObject.SetActive(false);
            Debug.Log(transform.name + ": Load Restart button", gameObject);
        }

        if (this.UI_BackToMenuButton == null)
        {
            this.UI_BackToMenuButton = GameObject.Find("BackToMenuButton").GetComponent<Button>();
            this.UI_BackToMenuButton.gameObject.SetActive(false);
            Debug.Log(transform.name + ": Load Resume button", gameObject);
        }    
    }

    private void Update()
    {
        UI_NumberOfHeartText.text = "x" + PlayerCtrl.Instance.playerLife.Heart.ToString();
        UI_ScoreText.text = ScoreManager.Instance.Score.ToString();
        ScoreManager.Instance.UpdateScore();
    }

    public void OnClickPauseButton()
    {
        this.UI_YourScoreText.text = "Your Score:\n" + ScoreManager.Instance.Score.ToString();
        this.UI_YourScoreText.gameObject.SetActive(true);
        if (ScoreManager.Instance.isGetNewHighScore) this.UI_NewHighScoreText.gameObject.SetActive(true);
        this.UI_PauseButton.gameObject.SetActive(false);
        this.UI_ResumeButton.gameObject.SetActive(true);
        this.UI_BackToMenuButton.gameObject.SetActive(true);
        this.PauseGame();
    }

    public void OnClickResumeButton()
    {
        this.UI_YourScoreText.gameObject.SetActive(false);
        this.UI_NewHighScoreText.gameObject.SetActive(false);
        this.UI_PauseButton.gameObject.SetActive(true);
        this.UI_ResumeButton.gameObject.SetActive(false);
        this.UI_BackToMenuButton.gameObject.SetActive(false);
        this.ResumeGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
        this.ResumeGame();
    }
}
