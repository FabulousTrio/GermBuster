using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	public int Health = 3;
	float speed = 3f;
	SpriteRenderer sprites;
	enum Disease{Headache, RunnyNose, Fever, StuffyNose};
	public bool Ill = false; //boolean for determining if player is already sick
	bool facingRight = true; //boolean for determining if player is facing right

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		movement();

		if(Health < 1)
		{
			Debug.Log("You Lose!");
		}
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

			if(facingRight) //if player is also facing right
			{
				flip(); //flip x axis
			}
		}
		
		if(Input.GetKey("d") || Input.GetKey("right")) /*Movement in the right direction*/
		{
			transform.position += Vector3.right * speed * Time.deltaTime;

			if(!facingRight) //if player is facing left
			{
				flip(); //flip x axis
			}
		}		


	}

	void flip()
	{
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x*= -1;
		transform.localScale = theScale;
	}

	IEnumerator Heal()
	{
		for(float timer = 10; timer >= 0; timer-= Time.deltaTime) //After x seconds
		yield return 0;
		speed = 2f; //set speed to two
		Debug.Log("You feel better.");
	}

	public void sick(int disease)
	{
		if(disease == 1) /*If the enemy id is 1 do this*/
		{
			speed = 0.5f;
		}
		/*Here we will add the other effects of other diseases at a a later time*/
		else if(disease == 2){} //add here later
		else if(disease == 3){} //add here later
		else if(disease == 4){} //add here later
		else{}

		StartCoroutine(Heal()); //Start a countdown so he can get better
	}

}
