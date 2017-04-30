using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using WindowsInput;
using UnityEngine.SceneManagement;

public class PlayerControlls : MonoBehaviour
{
    public InteractbleObject interactbleObject;
    public GameObject flashlight;
    public Animator animator;
    public ThirdPersonUserControl userControl;
    public GameObject batarangPrefab;
    public Transform batarangSpawnPosition;
    public Rigidbody rigidbody_;

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

    void Update()
    {
        PlayerControl();
    }

    void SetInteractObject(InteractbleObject obj)
    {
        interactbleObject = obj;
    }

    void PlayerControl()
    {
        if (Input.GetKeyDown(KeyCode.B))
            StartThrowBatarangAnimation();

        if (Input.GetKeyDown(KeyCode.J))
            ToggleFlashlight();

        if (Input.GetKeyDown(KeyCode.Tab))
            Interact();

        if (Input.GetKeyUp(KeyCode.Escape))
            LevelManager.Instance.LoadLevel(LevelType.Start);
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
        if (userControl.enabled && interactbleObject != null)
            interactbleObject.Interact(interactbleObject.gameObject.GetInstanceID());
    }

    void ToggleControls()
    {
        userControl.enabled = !userControl.enabled;
        if (userControl.enabled)
            rigidbody_.constraints = RigidbodyConstraints.FreezeRotation;
        else
            rigidbody_.constraints = RigidbodyConstraints.FreezeAll;
    }
}
