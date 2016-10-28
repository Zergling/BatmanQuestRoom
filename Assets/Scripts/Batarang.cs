using UnityEngine;
using System.Collections;

public class Batarang : MonoBehaviour
{
    public static string BATARANG_TAG = "_Batarang";
    public float speed;
    Camera camera;
    Vector3 direction;
    Transform myTransform;
	// Use this for initialization
	void Start ()
    {
        camera = Camera.main;
        direction = camera.transform.forward;
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        myTransform.position = Vector3.Lerp(myTransform.position, myTransform.position + direction * speed, Time.deltaTime);
        myTransform.Rotate(0, 20, 0);
	}

    void OnCollisionEnter (Collision c)
    {
        Debug.Log("destryo");
        Destroy(gameObject);
    }
}
