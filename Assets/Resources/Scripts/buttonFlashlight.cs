using UnityEngine;
using System.Collections;

public class buttonFlashlight : MonoBehaviour
{
    public GameObject light;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void onClick()
    {
        light.SetActive(!light.active);
    }
}
