using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

	int health = 3;
	float speed = 2f;
	SpriteRenderer sprites;
	
	bool sick = false;
	enum Disease{Headache, RunnyNose, Fever, StuffyNose};
	

	void movement()
	{
		
		if(Input.GetKey("a"))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		if(Input.GetKey("d"))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		if(Input.GetKey("w"))
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		
		if(Input.GetKey("s"))
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
		
		
	}
	
	void attack()
	{
		if(sick)
		{
			Disease myDisease;
			myDisease = Disease.Fever;
			
			if(myDisease == Disease.Fever)
			{
				speed = 1f;
			}
		}
	}
	
	
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		movement ();
		
	}
}
