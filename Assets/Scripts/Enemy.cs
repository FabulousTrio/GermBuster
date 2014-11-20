using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int Health = 1;
	public float speed = 1;
	float step;
	public SpriteRenderer sprites;
	private Transform target;
	public int id = 1;

	
	
	// Use this for initialization
	void Start () {
		//target = GameObject.Find ("player").transform;
		//StartCoroutine(MovetoPlayer());
	}
	
	// Update is called once per frame
	void Update () {
		movement ();
		
		if(Health == 0)
		{
			Debug.Log("Died");
		}
	}
	
	IEnumerator MovetoPlayer()
	{
		while(transform.position != target.position)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime); //moves towards the target
			yield return 0;
		}
	}
	
	void movement() //follow
	{
		target = GameObject.Find ("player").transform; //Finds the position of the GO named Eliot-kid
		step = speed * Time.deltaTime; //speed variable
		transform.position = Vector3.MoveTowards(transform.position, target.position, step); //moves towards the target
	}
	
	void attack()
	{
		
	}
	
	/*
		Changelog 11/19
		*Commented out the movement function and made the enemy move towards the player using a Coroutine function.
		*Difference now is that once the enemy reaches the player's position he stops moving.
	*/
}
