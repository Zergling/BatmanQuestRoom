using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{
    bool opened;
    Animation ani;
    public GameObject buttonInteract;
    string[] animations;

    // Use this for initialization
    void Start ()
    {
        opened = false;
        ani = this.GetComponent<Animation>();
        animations = new string[ani.GetClipCount()];
        int i = 0;
        foreach(AnimationState anistate in ani)
        {
            animations[i] = anistate.name;
            i++;
        }

        /*
        foreach(string str in animations)
        {
            Debug.Log(str);
        }
        */
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void interact()
    {
        if (opened == false)
        {
            ani.CrossFade(animations[0]);
            opened = true;
        }
        else
        {
            ani.CrossFade(animations[1]);
            opened = false;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag.Equals("Player"))
        {
            buttonInteract.SetActive(true);
            buttonInteract.SendMessage("setDoor", this.gameObject);
        }
    }

    void OnTriggerExit(Collider c)
    {
        buttonInteract.SetActive(false);
    }
}
