using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	GameManager gameManager;
	Weapon handsanitizer;

	float speed = 3f;
	SpriteRenderer sprites;
	enum Disease{Headache, RunnyNose, Fever, StuffyNose};
	bool facingRight = true; //boolean for determining if player is facing right
	
	/*Movement bounds*/
	float topbound = -0.085f;
	float bottombound = -1.827f;
	float leftbound = -3.46f;
	float rightbound = 3.6f;
	Transform playerGraphics; //Reference to graphics
	// Use this for initialization
	void Start () {
	
		gameManager = GameObject.Find ("player").GetComponent<GameManager>(); //save the reference to the script object

		handsanitizer = GameObject.Find("weapon").GetComponent<Weapon>();

		playerGraphics = transform.FindChild("Kid");
		
		if(playerGraphics == null)
		{
			Debug.LogError("No graphics object as a child of player");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		movement();

		if(gameManager.Health < 1)
		{
			Debug.Log("You Lose!");
		}
	}
	
	void movement()
	{	
		
		if(transform.position.y < topbound && (Input.GetKey("w") || Input.GetKey("up"))) /*Movement in the up direction*/
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		
		if(transform.position.y > bottombound && (Input.GetKey("s") || Input.GetKey("down"))) /*Movement in the down direction*/
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
		}
		
		
		if(transform.position.x > leftbound && (Input.GetKey("a") || Input.GetKey("left"))) /*Movement in the left direction*/
		{
			transform.position += Vector3.left * speed * Time.deltaTime;

			if(facingRight) //if player is also facing right
			{
				flip(); //flip x axis
			}
		}
		
		if(transform.position.x < rightbound && (Input.GetKey("d") || Input.GetKey("right"))) /*Movement in the right direction*/
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

		Vector3 theScale = playerGraphics.localScale;
		theScale.x*= -1;
		playerGraphics.localScale = theScale;
		
	}

	IEnumerator Heal()
	{
		for(float timer = 10; timer >= 0; timer-= Time.deltaTime) //After x seconds
		yield return 0;
		speed = 2f; //set speed to two
		handsanitizer.canShoot = true; //can shoot again
		Debug.Log("You feel better.");
	}

	public void sick(int disease)
	{
		if(disease == 1) /*If the enemy id is 1 do this*/
		{
			speed = 0.5f;
		}
		/*Here we will add the other effects of other diseases at a a later time*/
		else if(disease == 2){
			//speed = 5f;
			handsanitizer.canShoot = false; //Can't shoot

		} //add here later
		else if(disease == 3){ speed = 0;} //add here later
		else if(disease == 4){} //add here later
		else{}

		StartCoroutine(Heal()); //Start a countdown so he can get better
	}

}
