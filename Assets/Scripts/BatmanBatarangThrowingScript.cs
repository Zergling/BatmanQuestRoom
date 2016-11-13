using UnityEngine;
using System.Collections;

public class BatmanBatarangThrowingScript : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject Batarang;
	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void Throw()
    {
        Debug.Log("throwing!!");
        Instantiate(Batarang, SpawnPoint.transform.position, Quaternion.identity);
    }
}
