using UnityEngine;
using System.Collections;

public enum Level
{
    Start,
    Game
};

public class SceneSwitcher : MonoBehaviour
{
    public static Level level = Level.Start;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (level == Level.Start)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Debug.Log("Go To Game Level");
                SceneSwitcher.level = Level.Game;
                UnityEngine.SceneManagement.SceneManager.LoadScene("leve");
            }
        }

        if (level == Level.Game)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("Go to Start");
                SceneSwitcher.level = Level.Start;
                UnityEngine.SceneManagement.SceneManager.LoadScene("start");
            }
        }
        
	}
}
