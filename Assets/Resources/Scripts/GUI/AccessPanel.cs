using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccessPanel : MonoBehaviour
{
    public float timeBeforeFade;
    public bool b;
    float timer;

    public delegate void Callback();
    public static event Callback OnToggleTextHelpVisibilityEvent;

    void OnEnable()
    {
        timer = timeBeforeFade;
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (OnToggleTextHelpVisibilityEvent != null)
                OnToggleTextHelpVisibilityEvent();

            gameObject.SetActive(false);

            if (b)
                SceneManager.LoadScene("start");
        }
    }
}
