using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;
    public CameraHolder cameraHolder;
    private PlayerNavigator _playerNavigator;

    public int startHealth;
    private int _currentHealth;

    private bool _isDead;

    public PlayerHealthUI playerHealthUI;
    public PlayerGetHitUI playerGetHitUI;

    private void Awake()
    {
        _playerNavigator = GetComponent<PlayerNavigator>();
    }
    internal void RestartPlayer()
    {
        _isDead = false;
        gameObject.SetActive(true);
        _playerNavigator.RestartPlayerNavigator();
        RestartHealth();
    }

    private void RestartHealth()
    {
        _currentHealth = startHealth;
        UpdateHealth();
    }

    public void GetHit(int damage)
    {
        if (_isDead)
        {
            return;
        }
        playerGetHitUI.Show();
        gameDirector.audioManager.PlayHitSFX();
        cameraHolder.ShakeCamera(.5f,.5f);
        _currentHealth--;
        UpdateHealth();
        if (_currentHealth <= 0 && !_isDead)
        {
            Die();
        }
    }

    void UpdateHealth()
    {
        var ratio = Mathf.Max((float)_currentHealth / startHealth, 0);
        playerHealthUI.UpdateHealth(ratio);
    }

    private void Die()
    {
        gameObject.SetActive(false);
        _isDead = true;
        GameDirector.instance.LevelFailed();
    }
}
