﻿using UnityEngine;
using System.Collections;

public class PoliceLights : MonoBehaviour 
{

	[SerializeField] Light redLight;
	[SerializeField] Light blueLight;

	private Vector3 redTemp;
	private Vector3 blueTemp;

	[SerializeField] int speed;
	[SerializeField] Vector3 gap;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		redTemp.y += speed * Time.deltaTime;
		blueTemp.y -= speed * Time.deltaTime ;

		redLight.transform.eulerAngles = redTemp + gap;
		blueLight.transform.eulerAngles = blueTemp + gap;
	}
}
