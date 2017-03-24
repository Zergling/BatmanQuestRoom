using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum LevelType
{
    Start = 0,
    Game = 1
}

public class LevelManager
{
    // singleton
    private static LevelManager instance_ = null;

    public LevelManager()
    {
        levelType = LevelType.Start;
    }
    public static LevelManager Instance
    {
        get
        {
            if (instance_ == null)
                instance_ = new LevelManager();

            return instance_;
        }
    }

    // LevelManager
    LevelType levelType;

    public void Init()
    {
        Debug.Log("Level Manager Init");
    }

    public void LoadLevel(LevelType type)
    {
        string levelName = null;
        switch (type)
        {
            case LevelType.Start:
                levelName = "start";
                break;

            case LevelType.Game:
                levelName = "leve";
                break;

            default:
                break;
        }

        SceneManager.LoadScene(levelName);
    }
}
