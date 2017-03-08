using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractbleObject : MonoBehaviour
{

    public delegate void InteractAreaTrigger(InteractbleObject obj);
    public static event InteractAreaTrigger OnInteractAreaTriggerEvent;

    void OnEnable()
    {
        Batarang.OnCollisionEvent += Interact;
    }

    void OnDisable()
    {
        Batarang.OnCollisionEvent -= Interact;
    }

    // Use this for initialization
    void Start()
    {

    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag.Equals("Player") && OnInteractAreaTriggerEvent != null)
        {
            OnInteractAreaTriggerEvent(this);
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (OnInteractAreaTriggerEvent != null)
            OnInteractAreaTriggerEvent(null);
    }

    virtual public void Interact(int instanceId)
    {
        Debug.Log("InteractbleObject interact");
    }

}
