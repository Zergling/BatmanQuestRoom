using UnityEngine;
using System.Collections;

public class Terminal : MonoBehaviour
{
    public bool isTrueTerminal;
    public string code;
    public GameObject panel;


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
        GameObject[] canvas = GameObject.FindGameObjectsWithTag(LockPanelScript.LOCK_CANVAS_TAG);
        if (canvas.Length == 0)
        {
            GameObject obj = Instantiate<GameObject>(panel);
            obj.SendMessage("SetCodeString", code);
            obj.SendMessage("SetTrue", isTrueTerminal);
        }
    }
}
