using UnityEngine;
using System.Collections;

public class DeniedCanvasScript : MonoBehaviour
{
    float t;
    public float timer;
	// Use this for initialization
	void Start ()
    {
        t = 0.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        t += Time.deltaTime;
        if (t >= timer)
        {
            GameObject.Destroy(gameObject);
        }
	}
}
