using UnityEngine;
using System.Collections;
using WindowsInput;

public class PlayerMoving : MonoBehaviour
{
    private Transform myTransform;
    public float speed;
    public Vector3 movementVector;

	// Use this for initialization
	void Start ()
    {
        myTransform = this.transform;
        movementVector = new Vector3();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (movementVector.y == 0)
            {
                moveForward(1);
            }
            else
            {
                moveForward(0);
            }
            
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (movementVector.x == 0)
            {
                turnAround(-1);
            }
            else
            {
                turnAround(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (movementVector.x == 0)
            {
                turnAround(1);
            }
            else
            {
                turnAround(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            movementVector.y = 0;
        }

        if (movementVector.y > 0)
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
        }
        else
        {
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
        }

        if (movementVector.x > 0)
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.RIGHT);
        }
        else
        {
            InputSimulator.SimulateKeyUp(VirtualKeyCode.RIGHT);
        }

        if (movementVector.x < 0)
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.LEFT);
        }
        else
        {
            InputSimulator.SimulateKeyUp(VirtualKeyCode.LEFT);
        }
    }

    void moveForward(int value)
    {
        movementVector.y = value;
    }

    void turnAround(int value)
    {
        movementVector.x = value;
    }
}
