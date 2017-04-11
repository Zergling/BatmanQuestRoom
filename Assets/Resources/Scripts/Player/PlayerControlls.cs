using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using WindowsInput;
using UnityEngine.SceneManagement;

public class PlayerControlls : MonoBehaviour
{
    public Vector3 movementVector; // just to see in inspector

    public InteractbleObject interactbleObject;
    public GameObject flashlight;
    public Animator animator;
    public ThirdPersonUserControl userControl;
    public GameObject batarangPrefab;
    public Transform batarangSpawnPosition;

    void OnEnable()
    {
        InteractbleObject.OnInteractAreaTriggerEvent += SetInteractObject;
        Intercom.OnTogglePlayerControlsEvent += ToggleControls;
        LockPanelScript_vol2.OnPasswordEnterEvent += ToggleControls;
    }

    void OnDisable()
    {
        InteractbleObject.OnInteractAreaTriggerEvent -= SetInteractObject;
        Intercom.OnTogglePlayerControlsEvent -= ToggleControls;
        LockPanelScript_vol2.OnPasswordEnterEvent -= ToggleControls;
    }

    // Use this for initialization
    void Start ()
    {
        movementVector = new Vector3();
    }
	
	// Update is called once per frame
	void Update ()
    {
        PlayerControl();
	}

    void SetInteractObject(InteractbleObject obj)
    {
        interactbleObject = obj;
    }

    void PlayerControl()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (movementVector.y == 0)
                movementVector.y = 1;
            else
                movementVector.y = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("start");

        if (Input.GetKeyDown(KeyCode.S))
            movementVector.y = 0;

        if (Input.GetKeyDown(KeyCode.B))
            StartThrowBatarangAnimation();

        if (Input.GetKeyDown(KeyCode.J))
            ToggleFlashlight();

        if (Input.GetKeyDown(KeyCode.Tab))
            Interact();

        if (Input.GetKeyUp(KeyCode.F12))
            LevelManager.Instance.LoadLevel(LevelType.Start);

        if (movementVector.y == 1)
            InputSimulator.SimulateKeyDown(VirtualKeyCode.UP);
        else
            InputSimulator.SimulateKeyUp(VirtualKeyCode.UP);
    }

    void StartThrowBatarangAnimation()
    {
        animator.SetTrigger("Throw_Batarang");
    }

    public void ThrowBatarang()
    {
        Debug.Log("throwing!!");
        Instantiate(batarangPrefab, batarangSpawnPosition.position, Quaternion.identity);
    }

    void ToggleFlashlight()
    {
        flashlight.SetActive(!flashlight.activeSelf);
    }

    void Interact()
    {
        if (userControl.enabled)
            interactbleObject.Interact(interactbleObject.gameObject.GetInstanceID());
    }

    void ToggleControls()
    {
        userControl.enabled = !userControl.enabled;
    }
}
