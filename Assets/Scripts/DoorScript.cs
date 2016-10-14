using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{
    bool opened;
    Animation ani;
    public GameObject buttonInteract;

    // Use this for initialization
    void Start ()
    {
        opened = false;
        ani = this.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void interact()
    {
        if (opened == false)
        {
            ani.CrossFade("doorOpen");
            opened = true;
        }
        else
        {
            ani.CrossFade("doorClose");
            opened = false;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag.Equals("Player"))
        {
            buttonInteract.active = true;
            buttonInteract.SendMessage("setDoor", this.gameObject);
        }
    }

    void OnTriggerExit(Collider c)
    {
        buttonInteract.active = false;
    }
}
