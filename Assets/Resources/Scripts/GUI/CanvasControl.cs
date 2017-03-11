using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasControl : MonoBehaviour
{
    public GameObject controlHelp;

    void OnEnable()
    {
        AccessPanel.OnToggleTextHelpVisibilityEvent += ToggleControlHelpVisibility;
        Intercom.OnToggleTextHelpVisibilityEvent += ToggleControlHelpVisibility;
    }

    void OnDisable()
    {
        AccessPanel.OnToggleTextHelpVisibilityEvent -= ToggleControlHelpVisibility;
        Intercom.OnToggleTextHelpVisibilityEvent -= ToggleControlHelpVisibility;
    }

    void ToggleControlHelpVisibility()
    {
        controlHelp.SetActive(!controlHelp.activeInHierarchy);
    }
}
