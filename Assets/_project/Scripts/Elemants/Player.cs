using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;
    public CameraHolder cameraHolder;
    private PlayerNavigator _playerNavigator;
    private PlayerAnimator _playerAnimator;

    public int startHealth;
    private int _currentHealth;

    private bool _isDead;

    public PlayerHealthUI playerHealthUI;
    public PlayerGetHitUI playerGetHitUI;

    public Light flashLight;

    private void Awake()
    {
        _playerNavigator = GetComponent<PlayerNavigator>();
        _playerAnimator = GetComponent<PlayerAnimator>();
    }
    internal void RestartPlayer()
    {
        _isDead = false;
        gameObject.SetActive(true);
        _playerNavigator.RestartPlayerNavigator();
        RestartHealth();
        flashLight.enabled = true;
    }

    private void RestartHealth()
    {
        _currentHealth = startHealth;
        UpdateHealth();
    }

    public void GetHit(int damage, Vector3 dir)
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
            Die(dir);
        }
    }

    void UpdateHealth()
    {
        var ratio = Mathf.Max((float)_currentHealth / startHealth, 0);
        playerHealthUI.UpdateHealth(ratio);
    }

    private void Die(Vector3 dir)
    {
        flashLight.enabled = false;
        transform.LookAt(transform.position - dir);
        _playerAnimator.PlayFallBackAnimation();
        _isDead = true;
        GameDirector.instance.LevelFailed();
    }

    public bool GetIfDead()
    {
        return _isDead;
    }
}
