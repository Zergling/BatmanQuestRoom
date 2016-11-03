using UnityEngine;
using System.Collections;

public class DoorBatarangOpenScript : MonoBehaviour
{
    private GameObject door;

	// Use this for initialization
	void Start ()
    {
        door = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter(Collision c)
    {
        if (c.collider.tag.Equals(Batarang.BATARANG_TAG))
        {
            door.SendMessage("interact");
        }
    }
}
