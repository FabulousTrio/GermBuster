using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate;
	public int Damage = 1;
	public LayerMask whatToHit; //This is a variable that let's us target certain layers (We are targeting the everything except Player with this)
	SpriteRenderer sprites;

	float timetoSpawnEffect = 0; //for bullet displau
	public float effectSpawnRate = 10;

	float timeToFire = 0f;
	Transform firePoint;

	public Transform BulletTrailPrefab;
	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild("FirePoint"); //Instead of finding gameObject let's just find the child of Player which is the GameObject FirePoint (aka where the bullet will coming out of)
		
		if(firePoint == null) //if there is no firepoint Erick fucked up somehow
		{
			Debug.LogError("no firepoint!?!!!1111!!");
			
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(fireRate == 0) //checking if it is single fire weapon
		{
			if(Input.GetButtonDown("Fire1")) //if button down shoot
			{
				shoot();
			}
		}
		
		else //if weapon is not single burst
		{
			if(Input.GetButton("Fire1") && Time.time > timeToFire) //If holding button and if the time to fire is less than the time to fire 
			{
			
			timeToFire = Time.time + 1/fireRate; //next time we will fire is going to be the current time plus firerate
			
			shoot();
			}
		}
	}
	
	void shoot()
	{
		Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y); //getting mouseposition
		//Debug.Log(mousePosition);
		
		Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y); //Let's get the position of our FirePoint GameObject
		
		RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition-firePointPosition, 100, whatToHit); 
		//BulletTrailPrefab.transform.Translate(Vector3.MoveTowards(firePointPosition, (mousePosition - firePointPosition), 100f) * Time.deltaTime * 220);

		if(Time.time >= timetoSpawnEffect)
		{
			//effect();
			timetoSpawnEffect = Time.time + 1/effectSpawnRate;
		}

		/*
			Takes in certain parameters
			*First is the starting position, which we are setting to the position of FirePoint
			*Second is the direction the bullet is going. We get this by subtracting the starting position from the mouse position
			*Third is the distance we want it to travel
			*Fourth is a layerMask which is what we want the bullet to target
		*/
		
		Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition), Color.cyan); //Test to see distance bullet travelled
		
		if(hit.collider !=null)
		{
			//Debug.DrawLine(firePointPosition, hit.point, Color.red); //test to see the distance our bullet travelled
			Debug.Log("We hit " + hit.collider.name + " and did " + Damage + " damage."); 

			Enemy germ = hit.collider.GetComponent<Enemy>();

			germ.Health -= Damage;
			//Destroy(hit.collider.gameObject);//Destroy whatever we touched
		}
		
	}

	public void effect()
	{
		Instantiate (BulletTrailPrefab, firePoint.position, firePoint.rotation);

	}
}
