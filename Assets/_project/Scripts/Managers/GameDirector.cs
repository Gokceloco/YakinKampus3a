using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public static GameDirector instance;
    public LevelManager levelManager;
    public CoinManager coinManager;
    public FXManager fXManager;
    public AudioManager audioManager;
    public Player player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        RestartLevel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            LoadNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            LoadPreviousLevel();
        }
    }
    private void LoadNextLevel()
    {
        levelManager.levelNo += 1;
        RestartLevel();
    }
    private void LoadPreviousLevel()
    {
        levelManager.levelNo -= 1;
        RestartLevel();
    }    

    void RestartLevel()
    {
        levelManager.RestartLevel();
        player.RestartPlayer();
    }

    public void LevelCompleted()
    {
        Invoke(nameof(LoadNextLevel), 1f);
    }
}
