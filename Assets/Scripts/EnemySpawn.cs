using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour {

	public GameObject[] spawnPosition;
	private List<GameObject> enemies;
	public GameObject Enemy;
	public GameObject Enemy2;
	public float spawnDelay =2f;

	// Use this for initialization
	void Start () {
		enemies = new List<GameObject> ();
		StartCoroutine(Countdown());
		InvokeRepeating ("enemySpawner", spawnDelay, spawnDelay);
		
		
	}
	
	IEnumerator Countdown()
	{
		while(spawnDelay == 3f)
		{
			for(float timer = 15; timer >= 0; timer-= Time.deltaTime)
			yield return 0;
			spawnDelay = 1f;
			Debug.Log("timer over");
		}
		
	}
	// Update is called once per frame
	void Update () {
	}

	void enemySpawner()
	{
		int index = Random.Range (0, spawnPosition.Length);
		
		Vector3 pos = spawnPosition [index].transform.position;
		
		GameObject enemy = Instantiate (Enemy, pos, Quaternion.identity) as GameObject;
		GameObject enemy2 = Instantiate (Enemy2, pos, Quaternion.identity) as GameObject;

		enemy2.GetComponent<Enemy>().Health = 2;
		enemy2.GetComponent<Enemy>().id = 2;
		enemy2.GetComponent<Enemy>().speed = 4;

		enemies.Add (enemy);
		enemies.Add (enemy2);
		}






}
