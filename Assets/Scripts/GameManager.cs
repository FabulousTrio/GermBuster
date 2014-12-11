using UnityEngine;
using System.Collections;

public enum GameState
{
	Intro,
	Instructions,
	Game,
	GameOver,
}
;

public class GameManager : MonoBehaviour {
	private GameState gameState;

	private static GameManager instance; 
	
	public static GameManager Instance 
	{
		get {
			if (instance == null) {
				instance = (GameManager)FindObjectOfType (typeof(GameManager));
			}	
			return instance; //Returns the instance of this singleton.
		}
	}

	
	//public GameObject player;
	public int Health = 3;
	public int GermsKilled{get; set;}

	// Use this for initialization
	void Start () {

			gameState = GameState.Intro;
			//we don't want our GameManager to be destroyed between levels
			DontDestroyOnLoad (instance);
		GermsKilled = 0;

	}

	void OnLevelWasLoaded (int level)
	{
		if (level == 2) {
			gameState = GameState.Game;
			InitGame ();
		}
	}

	public void InitGame ()
	{

	}
	// Update is called once per frame
	void Update () {
		
	}
	
	
}
