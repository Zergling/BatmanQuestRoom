using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Intercom : InteractbleObject, IPointerClickHandler
{
    public bool isTrueIntercom;
    public string code;
    public LockPanelScript_vol2 lockCanvas;

    public delegate void Callback();
    public static event Callback OnTogglePlayerControlsEvent;
    public static event Callback OnToggleTextHelpVisibilityEvent;

    public override void Interact(int instanceId)
    {
        if (!lockCanvas.Show())
            return;

        if (instanceId != gameObject.GetInstanceID())
            return;

        base.Interact(instanceId);
        if (OnTogglePlayerControlsEvent != null)
            OnTogglePlayerControlsEvent();

        if (OnToggleTextHelpVisibilityEvent != null)
            OnToggleTextHelpVisibilityEvent();

        lockCanvas.SetTrue(isTrueIntercom);
        lockCanvas.SetCodeString(code);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Interact(gameObject.GetInstanceID());
    }

    void TogglePlayerControls()
    {
        if (OnTogglePlayerControlsEvent != null)
            OnTogglePlayerControlsEvent();
    }
}
