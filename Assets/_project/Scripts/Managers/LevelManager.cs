using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Level> levels;

    public Level currentLevel;

    public int levelNo;

    internal void RestartLevel()
    {
        DeleteCurrentLevel();
        CreateNewLevel();
    }

    internal void StopEnemies()
    {
        var enemies = currentLevel.GetComponentsInChildren<Enemy>();
        foreach (var e in enemies)
        {
            e.PlayerIsDead();
        }
    }

    private void CreateNewLevel()
    {
        levelNo = Mathf.Clamp(levelNo, 1, levels.Count);
        currentLevel = Instantiate(levels[levelNo-1]);
    }

    private void DeleteCurrentLevel()
    {
        if (currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
    }
}
