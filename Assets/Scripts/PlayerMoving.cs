using UnityEngine;
using System.Collections;
using WindowsInput;

public class PlayerMoving : MonoBehaviour
{
    private Transform myTransform;
    public float speed;
    public Vector3 movementVector;
    public GameObject interactObject;
    public BatmanBatarangThrowingScript throwScript;
    public GameObject flashlight;
    Animator char_anim;

    // Use this for initialization
    void Start ()
    {
        myTransform = this.transform;
        movementVector = new Vector3();
        char_anim = gameObject.GetComponent<Animator>();
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

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            char_anim.SetTrigger("Throw_Batarang");
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            flashlight.SetActive(!flashlight.activeSelf);
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

    void SetInteractObject(GameObject obj)
    {
        interactObject = obj;
    }

    void Interact()
    {
        if (interactObject != null)
        {
            Debug.Log("Interact");
            interactObject.SendMessage("interact");
        }
    }
}
