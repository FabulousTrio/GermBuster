using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {

	public GameObject[] spawnPosition;
	private List<GameObject> enemies;
	public GameObject Enemy;

	// Use this for initialization
	void Start () {
		enemies = new List<GameObject> ();
		InvokeRepeating ("enemySpawner", 1f, 1f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void enemySpawner()
	{
		int index = Random.Range (0, spawnPosition.Length);

		Vector3 pos = spawnPosition [index].transform.position;
		GameObject enemy = Instantiate (Enemy, pos, Quaternion.identity) as GameObject;
		enemies.Add (enemy);

		}






}
