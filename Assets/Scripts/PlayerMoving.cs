using UnityEngine;
using System.Collections;

public class PlayerMoving : MonoBehaviour
{
    public GameObject sphere;
    private Transform sphereTransform;
    private Transform myTransform;
    public float speed;
    public Vector3 movementVector;

	// Use this for initialization
	void Start ()
    {
        sphereTransform = sphere.transform;
        myTransform = this.transform;
        movementVector = new Vector3();
	}
	
	// Update is called once per frame
	void Update ()
    {
        movementVector.y = Input.GetAxis("Vertical");
        movementVector.x = Input.GetAxis("Horizontal");

        myTransform.position = Vector3.Lerp(myTransform.position, myTransform.position + sphereTransform.forward * movementVector.y * speed, Time.deltaTime * 5);
        myTransform.position = Vector3.Lerp(myTransform.position, myTransform.position + sphereTransform.right * movementVector.x * speed, Time.deltaTime * 5);
    }
}
