using UnityEngine;
using System.Collections;

public class BatSignRotation : MonoBehaviour
{
    Transform myTransform;
    // Use this for initialization
    void Start()
    {
        myTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        myTransform.Rotate(0, Time.deltaTime * 100, 0);
    }
}
