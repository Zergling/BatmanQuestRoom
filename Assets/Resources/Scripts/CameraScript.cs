using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public GameObject cameraPoint;
    public GameObject cameraViewPoint;

    // Use this for initialization
    void Start ()
    {
        //this.transform.position = cameraPoint.transform.position;
        this.transform.LookAt(cameraViewPoint.transform);
    }
	
	// Update is called once per frame
	void Update ()
    {
        //this.transform.position = Vector3.Lerp(this.transform.position, cameraPoint.transform.position, Time.deltaTime * 5);
        
    }
}
