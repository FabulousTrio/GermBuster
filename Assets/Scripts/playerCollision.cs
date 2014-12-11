using UnityEngine;
using System.Collections;

public class playerCollision : MonoBehaviour {

	Player me; // GO reference for the player
	GameManager gameManager;
	// Use this for initialization
	void Start () {
		me = GameObject.Find ("player").GetComponent<Player>(); //Get the Sick component from the GO
		gameManager = GameObject.Find ("player").GetComponent<GameManager>(); //Get the GameManager script from the GO
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		//If the game object is an enemy...
		if (other.gameObject.name == "enemy(Clone)" || other.gameObject.name == "enemy2(Clone)") 
		{

			Debug.Log("Enemy Collided");
			Enemy germ = other.GetComponent<Enemy>(); //make  a new reference to the collider, get its script

			/* Infect */

			me.sick(germ.id); //Call the player's sick method and set the disease to the germ's id
				

		 	Destroy(other.gameObject); //kill the germ
			gameManager.Health--;
			Debug.Log("Health: " + gameManager.Health);

		}
	}

	
	
}
