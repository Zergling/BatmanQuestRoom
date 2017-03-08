using UnityEngine;
using System.Collections;

public class Throw_Batarang_Script : MonoBehaviour 
{

	GameObject character;
	Animator char_anim;

	// Use this for initialization
	void Start () 
	{
		character = GameObject.Find("ThirdPersonController");
		char_anim = character.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void onClick()
	{
		char_anim.SetTrigger("Throw_Batarang");
	}
}
