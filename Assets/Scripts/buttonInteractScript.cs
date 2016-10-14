using UnityEngine;
using System.Collections;

public class buttonInteractScript : MonoBehaviour
{
    private GameObject nearDoor;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void setDoor(GameObject door)
    {
        nearDoor = door;
    }

    public void onClick()
    {
        if (nearDoor != null)
        {
            nearDoor.SendMessage("interact");
        }
    }
}
