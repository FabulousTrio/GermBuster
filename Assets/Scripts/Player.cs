using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	int health = 3;
	float speed = 2f;
	SpriteRenderer sprites;
	
	bool Sick = false;
	enum Disease{Headache, RunnyNose, Fever, StuffyNose};
	

	
	
	/*if(Sick)
	{
		
	}*/
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		movement();
	}
	
	void movement()
	{
	
		if(Input.GetKey("w") || Input.GetKey("up")) /*Movement in the up direction*/
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		
		if(Input.GetKey("s") || Input.GetKey("down")) /*Movement in the down direction*/
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
		
		
		if(Input.GetKey("a") || Input.GetKey("left")) /*Movement in the left direction*/
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		if(Input.GetKey("d") || Input.GetKey("right")) /*Movement in the right direction*/
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}		
		
	}
	
	void attack()
	{
		
	}
}
