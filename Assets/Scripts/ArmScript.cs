using UnityEngine;
using System.Collections;

public class ArmScript : MonoBehaviour {

	public int rotationOffset = 180;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //subtract player position from mouse position 
		difference.Normalize(); //Make vector equal to 1 to keep same proportions. all that Math 185 for nothing!

		float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Finding the angle and converting to degrees
		transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);

	}
}
