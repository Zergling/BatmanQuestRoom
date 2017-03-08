using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractbleObject
{
    public Animation animation;

    string[] animationsNames;
    bool opened;

    void Start()
    {
        opened = false;
        animation = this.GetComponent<Animation>();
        animationsNames = new string[animation.GetClipCount()];
        int i = 0;
        foreach (AnimationState anistate in animation)
        {
            animationsNames[i] = anistate.name;
            i++;
        }
    }

    public override void Interact(int instanceId)
    { 
        if (instanceId != gameObject.GetInstanceID())
            return;

        if (opened == false)
        {
            animation.CrossFade(animationsNames[0]); // open
            opened = true;
        }
        else
        {
            animation.CrossFade(animationsNames[1]); // close
            opened = false;
        }

        GameObject[] batarangs = GameObject.FindGameObjectsWithTag(Batarang.BATARANG_TAG);
        foreach (GameObject obj in batarangs)
        {
            Vector3 mypos = transform.position;
            Vector3 batpos = obj.transform.position;
            float d = Mathf.Sqrt(Mathf.Pow(mypos.x - batpos.x, 2) + Mathf.Pow(mypos.y - batpos.y, 2) + Mathf.Pow(mypos.z - batpos.z, 2));

            if (d <= 3.0f)
            {
                Destroy(obj);
            }
        }
    }
     
}
