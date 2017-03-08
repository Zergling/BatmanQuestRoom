using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Intercom : InteractbleObject, IPointerClickHandler
{
    public delegate void Callback();
    public static event Callback OnTogglePlayerControlsEvent;

    void OnEnable() { }

    void OnDisable() { }

    public override void Interact(int instanceId)
    {
        if (instanceId != gameObject.GetInstanceID())
            return;

        base.Interact(instanceId);
        if (OnTogglePlayerControlsEvent != null)
            OnTogglePlayerControlsEvent();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Interact(gameObject.GetInstanceID());
    }
}
