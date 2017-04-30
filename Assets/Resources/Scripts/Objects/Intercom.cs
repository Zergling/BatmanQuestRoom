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

    void OnEnable()
    {
        Batarang.OnCollisionEvent += OnCollision;
    }

    void OnDisable()
    {
        Batarang.OnCollisionEvent -= OnCollision;
    }

    public override void Interact(int instanceId)
    {
        if (instanceId != gameObject.GetInstanceID())
            return;

        if (!lockCanvas.Show())
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

    void OnCollision(int instanceId)
    {
        Interact(instanceId);
    }
}
