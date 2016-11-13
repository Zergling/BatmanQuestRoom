using UnityEngine;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Go to Start");
            UnityEngine.SceneManagement.SceneManager.LoadScene("start");
        }
	}

    public void onClick()
    {
        Debug.Log("Go to GameLevel");
        UnityEngine.SceneManagement.SceneManager.LoadScene("leve");
    }
}
