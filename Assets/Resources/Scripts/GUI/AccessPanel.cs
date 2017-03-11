﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessPanel : MonoBehaviour
{
    public float timeBeforeFade;
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
        }
    }
}
