using UnityEngine;
using System.Collections;
using WindowsInput;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerMoving : MonoBehaviour
{
    private Transform myTransform;
    public float speed;
    public Vector3 movementVector;
    public GameObject interactObject;
    public BatmanBatarangThrowingScript throwScript;
    public GameObject flashlight;
    public Text interactText;
    Animator char_anim;
    ThirdPersonUserControl controls;

    // Use this for initialization
    void Start ()
    {
        myTransform = this.transform;
        movementVector = new Vector3();
        char_anim = gameObject.GetComponent<Animator>();
        interactText.gameObject.SetActive(false);
        controls = GetComponent<ThirdPersonUserControl>();
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
        if (obj == null)
        {
            interactText.gameObject.SetActive(false);
        }
        else
        {
            interactText.gameObject.SetActive(true);
        }
        
    }

    void Interact()
    {
        if (interactObject != null)
        {
            Debug.Log("Interact");
            interactObject.SendMessage("interact");
            if (interactObject.tag.Equals(Terminal.TAG))
            {
                DisableMoving();
            }
        }
    }

    void OnTriggerExit(Collider c)
    {
        SetInteractObject(null);
    }

    void DisableMoving()
    {
        GetComponent<ThirdPersonUserControl>().enabled = false;
    }

    void EnableMoving()
    {
        GetComponent<ThirdPersonUserControl>().enabled = true;
    }
}
