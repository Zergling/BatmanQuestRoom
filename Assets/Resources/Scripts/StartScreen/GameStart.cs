using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    void Awake()
    {
        LevelManager.Instance.Init();
    }
	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F11))
            LevelManager.Instance.LoadLevel(LevelType.Game);
	}
}
