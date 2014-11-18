using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health;
	public float speed = 1;
	float step;
	SpriteRenderer sprites;
	private Transform target;
	public int id = 1;

	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		movement ();
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
}
