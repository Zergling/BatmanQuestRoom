using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Batarang : MonoBehaviour
{
    public static string BATARANG_TAG = "_Batarang";
    public static Queue<GameObject> batarangs = new Queue<GameObject>();
    public float speed;
    Camera camera;
    Vector3 direction;
    Transform myTransform;
    bool isMoving;

    public delegate void OnCollision(int instanceId);
    public static event OnCollision OnCollisionEvent;
	// Use this for initialization
	void Start ()
    {
        camera = Camera.main;
        direction = camera.transform.forward;
        myTransform = transform;
        isMoving = true;

        if (batarangs.Count >= 10)
        {
            Debug.Log("max batarangs!");
            GameObject first = batarangs.Dequeue();
            Destroy(first);
            batarangs.Enqueue(gameObject);
        }
        else
        {
            batarangs.Enqueue(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isMoving == true)
        {
            myTransform.position = Vector3.Lerp(myTransform.position, myTransform.position + direction * speed, Time.deltaTime);
            myTransform.Rotate(0, 20, 0);
        }
	}

    void OnCollisionEnter (Collision c)
    {
        isMoving = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;
        if (OnCollisionEvent != null)
            OnCollisionEvent(c.gameObject.GetInstanceID());
    }
}
