using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessPanel : MonoBehaviour
{
    public float timeBeforeFade;
    float timer;

    void OnEnable()
    {
        timer = timeBeforeFade;
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            gameObject.SetActive(false);
	}
}
