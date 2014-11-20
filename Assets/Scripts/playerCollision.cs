using UnityEngine;
using System.Collections;

public class playerCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "enemy(Clone)")
		{
			Debug.Log("Enemy Collided");
			//StartCoroutine(Fade (other.gameObject));
			//Destroy(other.gameObject);
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
