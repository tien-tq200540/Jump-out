using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : TienMonoBehaviour
{
    static private ScoreManager instance;
    static public ScoreManager Instance { get => instance; }

    [SerializeField] private int score = 0;
    public int Score { get => score; }
    [SerializeField] private int highScore;
    private int oldPos, newPos;

    protected override void Awake()
    {
        base.Awake();
        instance = this;
        if (PlayerPrefs.HasKey("HighScore")) highScore = PlayerPrefs.GetInt("HighScore");
    }

    private void Start()
    {
        oldPos = (int)PlayerCtrl.Instance.transform.position.y;
    }


    public void UpdateScore()
    {
        if (PlayerCtrl.Instance.playerStatus.IsPlayerFalling())
        {
            newPos = (int)Mathf.Round(PlayerCtrl.Instance.transform.position.y);
            score = score + Mathf.Abs(newPos - oldPos);
            if (score > highScore) UpdateHighScore();
            oldPos = newPos;
        }
    }

    public void UpdateHighScore()
    {
        highScore = score;
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }
}
