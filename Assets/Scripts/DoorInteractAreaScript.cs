using UnityEngine;
using System.Collections;

public class DoorInteractAreaScript : MonoBehaviour
{
    public GameObject buttonInteract;
    public GameObject door;
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
            buttonInteract.SetActive(true);
            buttonInteract.SendMessage("setDoor", door);
        }
    }

    void OnTriggerExit(Collider c)
    {
        buttonInteract.SetActive(false);
    }
}
