using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//public GameObject player;
	public int Health = 3;
	public int GermsKilled{get; set;}
	
	// Use this for initialization
	void Start () {
	
		GermsKilled = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
}
