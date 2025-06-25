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

    public PlayerHealthUI playerHealthUI;
    public MainMenu mainMenu;
    public VictoryUI victoryUI;
    public MiniMapUI miniMapUI;

    public GameState gameState;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        player.gameObject.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeButtonPressed();
        }
    }

    private void EscapeButtonPressed()
    {
        gameState = GameState.MainMenu;
        Time.timeScale = 0;
        mainMenu.Show(true);
        HideInGameUI();
    }

    public void LoadNextLevel()
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
        gameState = GameState.GamePlay;
        levelManager.RestartLevel();
        player.RestartPlayer();
        ShowInGameUI();
    }

    public void LevelCompleted()
    {
        victoryUI.Show(1);
        HideInGameUI();
    }

    public void LevelFailed()
    {
        gameState = GameState.FailUI;
        levelManager.StopEnemies();
        HideInGameUI();
    }

    public void StartButtonPressed()
    {
        RestartLevel();
    }

    public void ShowInGameUI()
    {
        playerHealthUI.Show();
        miniMapUI.Show();
    }

    public void HideInGameUI()
    {
        playerHealthUI.Hide();
        miniMapUI.Hide();
    }
}

public enum GameState
{
    MainMenu,
    GamePlay,
    VictoryUI,
    FailUI,
}