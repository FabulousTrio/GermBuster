using UnityEngine;
using System.Collections;

public class ArmScript : MonoBehaviour {

	public int rotationOffset = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //Subtracting the position of the player from mouseposition
		difference.Normalize(); //Normalizing vector. Meaning that the sum f the vector will equal 1
		
		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Finding angle in degrees
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
	}
}
