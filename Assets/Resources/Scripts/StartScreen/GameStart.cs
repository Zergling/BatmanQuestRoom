using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    void Awake()
    {
        //LevelManager.Instance.Init();

        Arduino_script.Instance.ConnectToArduino();
        Arduino_script.Instance.WriteToArduino("INIT");
    }

    private void OnApplicationQuit()
    {
        Arduino_script.Instance.CloseStream();
    }
    // Use this for initialization
    void Start ()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F11))
            SceneManager.LoadScene("leve");
    }

    /*void Update()
    {
        if (Input.GetKeyUp(KeyCode.F11))
            LevelManager.Instance.LoadLevel(LevelType.Game);

	}*/
}
