using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public GameObject Zombie;
	public GameObject Spoder;
	public GameObject player;
	private Player pScript;
	public GameObject spPoints;
	private SpawnPoints spScript;

	public Text levelText;

	public float timeToSpawn = .1f;
	private float nextSpawn = 0;

	private int level = 2; //first level start at int 2 for log scale
	private int difficulty = 4; // increase for more enemies, decrease for less
	private int killCount = 0;
	private int enemyCount;

	void Start () {
		pScript = player.GetComponent<Player> ();
		spScript = spPoints.GetComponent<SpawnPoints> ();
		setupLevel (level);
	}

	void Update () {
		levelText.text = "Level: "+(level - 1);

		if (PauseMenuManager.gameIsPaused) {
			//anything that would happen when game is paused
			//if it does nothing:
			return ;

		}
		
	}

	public void addKill() {
		killCount++;
		if (killCount == enemyCount) {
			transitionLevel ();
		}
	}

	private void transitionLevel () {
		killCount = 0;
		level++;
		setupLevel (level); // TODO
		Debug.Log("STARTED LEVEL " + (level-1));
	}

	private void setupLevel (int level)
	{
		enemyCount = (int)(Mathf.Log (level, 2f) * difficulty);
		StartCoroutine (spawnEnemy (enemyCount));
	}

	public static void KillPlayer (Player player)
	{
		//Destroy (player.gameObject);

	}

	IEnumerator spawnEnemy (int count)
	{
		
		for (int i = 0; i < count; i++) {
			if (pScript.gameOver) {
				
			} else {
				yield return new WaitForSeconds (timeToSpawn + Random.Range (-0.5f, 0.5f) - (level));

				Transform sp = spScript.spawnPoints [Random.Range (0, spScript.spawnPoints.Length - 1)];
				if (Random.Range (0, 2) == 0)
					Instantiate (Zombie, sp.position, sp.rotation);
				else
					Instantiate (Spoder, sp.position, sp.rotation);

				Debug.Log ("Spawned enemy");
			}

		}

	}



}
