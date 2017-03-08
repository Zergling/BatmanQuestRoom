using UnityEngine;
using System.Collections;
using WindowsInput;

public class ScreenButtonScript : MonoBehaviour
{
    public int moveCode; // 1 - forw; 2 - back; 3 - right; 4 - left;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void onPointerDown()
    {
        Debug.Log("down");
        switch(moveCode)
        {
            case 1:
                {
                    InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
                    break;
                }

            case 2:
                {
                    break;
                }

            case 3:
                {
                    InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT);
                    break;
                }

            case 4:
                {
                    InputSimulator.SimulateKeyDown(VirtualKeyCode.LEFT);
                    break;
                }
        }
    }

    public void onPointerUp()
    {
        Debug.Log("up");
        switch (moveCode)
        {
            case 1:
                {
                    InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
                    break;
                }

            case 2:
                {
                    break;
                }

            case 3:
                {
                    InputSimulator.SimulateKeyUp(VirtualKeyCode.RIGHT);
                    break;
                }

            case 4:
                {
                    InputSimulator.SimulateKeyUp(VirtualKeyCode.LEFT);
                    break;
                }
        }
    }
}
