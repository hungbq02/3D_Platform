using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private const string HighestLevelKey = "HighestLevelCUnlock";
    public int currentLevel;
    public void CheckHighestLevelUnlock(int levelIndex)
    {
        int highest = PlayerPrefs.GetInt(HighestLevelKey, 1);
        if (levelIndex > highest)
        {
            PlayerPrefs.SetInt(HighestLevelKey, levelIndex);
            PlayerPrefs.Save();
        }
    }
    public bool IsLevelUnlock(int levelIndex)
    {
        int highest = PlayerPrefs.GetInt(HighestLevelKey, 1);
        return levelIndex <= highest;
    }
}
