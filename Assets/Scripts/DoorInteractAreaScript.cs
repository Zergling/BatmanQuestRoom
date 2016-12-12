using UnityEngine;
using System.Collections;

public class DoorInteractAreaScript : MonoBehaviour
{
    public const string TAG = "_InteractArea";
    public GameObject buttonInteract;
    public GameObject interactObject;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    
    void OnTriggerEnter(Collider c)
    {
        if (c.tag.Equals("Player"))
        {
            //buttonInteract.SetActive(true);
            c.gameObject.SendMessage("SetInteractObject", interactObject);
        }
    }

    void OnTriggerExit(Collider c)
    {
        //buttonInteract.SetActive(false);
        c.gameObject.SendMessage("SetInteractObject", null);
    }
    
}
