using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health;
	public float speed = 1;
	SpriteRenderer sprites;
	public Transform target;
	
	void movement() //follow
	{
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
	
	void attack()
	{
		
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		movement ();
	}
}
