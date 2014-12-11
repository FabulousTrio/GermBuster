using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameManager gameManager;
		
	/*Fields*/
	public int Health = 1;
	public float speed = 1;
	float step;
	public SpriteRenderer sprites;
	private Transform target;
	public int id = 1;

	
	
	// Use this for initialization
	void Start () {
	
		gameManager = GameObject.Find ("player").GetComponent<GameManager>(); //save the reference to the script object
		
	}
	
	// Update is called once per frame
	void Update () {
		movement ();
		
		if(Health < 1)
		{
			die();
		}
	}

	void movement() //follow
	{
		target = GameObject.Find ("player").transform; //Finds the position of the GO named Eliot-kid
		step = speed * Time.deltaTime; //speed variable
		transform.position = Vector3.MoveTowards(transform.position, target.position, step); //moves towards the target
	}
	
	void die(){
		Destroy(gameObject);
		
		gameManager.GermsKilled++;
		Debug.Log("Germs Killed: " + gameManager.GermsKilled);
	}
}
