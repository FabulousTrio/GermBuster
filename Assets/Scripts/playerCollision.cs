using UnityEngine;
using System.Collections;

public class playerCollision : MonoBehaviour {

	Player me; // GO reference for the player

	// Use this for initialization
	void Start () {
		me = GameObject.Find ("player").GetComponent<Player>(); //Get the Sick component from the GO
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "enemy(Clone)")
		{

			Debug.Log("Enemy Collided");
			Enemy germ = other.GetComponent<Enemy>(); //make  a new reference to the collider, get its script

			/* Infect */
			if (me.Ill == false) //If player is not ill yet do the following
			{
				me.sick(germ.id); //Call the player's sick method and set the disease to the germ's id
				me.Ill = true; //make the player ill
			}

		 	Destroy(other.gameObject); //kill the germ


		}
	}

	/*IEnumerator Fade(GameObject target)
	{
		for(float f = 1f; f >= 0; f -= 0.007f)
		{
			//SpriteRenderer c = target.sprites;
			//c.a =f;
			//target.color = c;
			target.sprites = f;
			yield return null;
		}
	}*/
	
}
