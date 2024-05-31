using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager: TienMonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        LoadGameManager();
    }

    protected virtual void LoadGameManager()
    {
        if (GameManager.Instance != null) Debug.LogError("Only 1 GameManager allow");
        instance = this;
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
